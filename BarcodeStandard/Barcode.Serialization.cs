using BarcodeStandard;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace BarcodeLib
{
    public partial class Barcode
    {
        #region XML Methods

        private SaveData GetSaveData(Boolean includeImage = true)
        {
            SaveData saveData = new SaveData();
            saveData.Type = EncodedType.ToString();
            saveData.RawData = RawData;
            saveData.EncodedValue = EncodedValue;
            saveData.EncodingTime = EncodingTime;
            saveData.IncludeLabel = IncludeLabel;
            saveData.Forecolor = ColorTranslator.ToHtml(ForeColor);
            saveData.Backcolor = ColorTranslator.ToHtml(BackColor);
            saveData.CountryAssigningManufacturingCode = Country_Assigning_Manufacturer_Code;
            saveData.ImageWidth = Width;
            saveData.ImageHeight = Height;
            saveData.RotateFlipType = RotateFlipType;
            saveData.LabelPosition = (int)LabelPosition;
            saveData.LabelFont = LabelFont.ToString();
            saveData.ImageFormat = ImageFormat.ToString();
            saveData.Alignment = (int)Alignment;

            //get image in base 64
            if (includeImage)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    EncodedImage.Save(ms, ImageFormat);
                    saveData.Image = Convert.ToBase64String(ms.ToArray(), Base64FormattingOptions.None);
                }//using
            }
            return saveData;
        }
        public string ToJSON(Boolean includeImage = true)
        {
            byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(GetSaveData(includeImage));
            return (new UTF8Encoding(false)).GetString(bytes); //no BOM
        }

        public string ToXML(Boolean includeImage = true)
        {
            if (EncodedValue == string.Empty)
                throw new Exception("EGETXML-1: Could not retrieve XML due to the barcode not being encoded first.  Please call Encode first.");
            else
            {
                try
                {
                    using (SaveData xml = GetSaveData(includeImage))
                    {
                        using (Utf8StringWriter sw = new Utf8StringWriter())
                        {
                            _SaveDataXmlSerializer.Serialize(sw, xml);
                            return sw.ToString();
                        }
                    }//using
                }//try
                catch (Exception ex)
                {
                    throw new Exception("EGETXML-2: " + ex.Message);
                }//catch
            }//else
        }
        public static SaveData FromJSON(Stream jsonStream)
        {
            using (jsonStream)
            {
                if (jsonStream is MemoryStream)
                {
                    return JsonSerializer.Deserialize<SaveData>(((MemoryStream)jsonStream).ToArray());
                }
                else
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        jsonStream.CopyTo(memoryStream);
                        return JsonSerializer.Deserialize<SaveData>(memoryStream.ToArray());
                    }
                }

            }
        }
        public static SaveData FromXML(Stream xmlStream)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(xmlStream))
                {
                    return (SaveData)_SaveDataXmlSerializer.Deserialize(reader);
                }
            }//try
            catch (Exception ex)
            {
                throw new Exception("EGETIMAGEFROMXML-1: " + ex.Message);
            }//catch
        }
        public static Image GetImageFromSaveData(SaveData saveData)
        {
            try
            {
                //loading it to memory stream and then to image object
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(saveData.Image)))
                {
                    return Image.FromStream(ms);
                }//using
            }//try
            catch (Exception ex)
            {
                throw new Exception("EGETIMAGEFROMXML-1: " + ex.Message);
            }//catch
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => new UTF8Encoding(false);
        }
        #endregion
    }
}
