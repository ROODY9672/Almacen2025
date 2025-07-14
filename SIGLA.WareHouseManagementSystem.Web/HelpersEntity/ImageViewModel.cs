using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;

namespace SIGLA.WareHouseManagementSystem.Web.HelpersEntity
{
  public class ImageViewModel
  {
    public byte[] CompressImage(byte[] byteArray)
    {
      using (var image = Image.Load(byteArray))
      {
        image.Mutate(x => x.Resize(new ResizeOptions
        {
          Mode = ResizeMode.Max,
          Size = new Size(600, 800)
        }));

        using (var ms = new MemoryStream())
        {
          image.Save(ms, new JpegEncoder { Quality = 85 }); // puedes ajustar la calidad aquí
          return ms.ToArray();
        }
      }
    }
  }
}
