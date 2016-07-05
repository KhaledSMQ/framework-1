// ============================================================================
// Project: Framework
// Name/Class: ImageExtension
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 17/Jun/2013
// Company: Coop4Creativity
// Description: Image extension methods.
// ============================================================================                    

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Framework.Drawing.Extensions
{
    public static class ImageExtension
    {
        //
        // transforms any image into a thumbnail of 155x155 with minimum loss
        // saves the generated file as: thumb_[original_file_name].original_extension
        // 
        // TODO: Remove the 155x155 from this method.
        //

        public static void ImageTransformation(string input, string output, int width, int height)
        {
            Image img = GetImageFromFile(input);
            if (null != img)
            {
                Image imgTransformed = img.ForceResizeWithMinimumCanvasLoss(width, height, false);
                SaveImageToFile(imgTransformed, output);
            }
        }

        //
        // Read image from file
        // returns null if the path is invalid
        //

        public static Image GetImageFromFile(string path)
        {
            Image i = null;
            try
            {
                i = Image.FromFile(path);
            }
            catch (Exception) { }
            return i;
        }

        //
        // Generate a byte array from an image.
        //

        public static byte[] ImageToByteArray(Image imageIn, System.Drawing.Imaging.ImageFormat format)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, format);
            return ms.ToArray();
        }

        //
        // Generate an image from a byte array.
        //

        public static Image ImageFromByteArray(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        // 
        // Write Image to file
        //

        public static void SaveImageToFile(Image image, string path)
        {
            image.Save(path);
        }

        // 
        // Write Image to file
        //

        public static void SaveImageToFile(Image image, string path, ImageFormat format)
        {
            image.Save(path, format);
        }

        // 
        // Crops an image according to a selection rectangle
        //

        public static Image Crop(this Image image, Rectangle selection)
        {
            Bitmap bmp = image as Bitmap;

            // 
            // Check if it is a bitmap:
            //

            if (bmp == null)
            {
                throw new ArgumentException("Null Bitmap");
            }

            // 
            // Crop the image:
            //

            int w = bmp.Width;
            int h = bmp.Height;
            int rW = selection.Width;
            int rH = selection.Height;

            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

            // 
            // Release the resources:
            //

            image.Dispose();

            return cropBmp;
        }

        // 
        // Resize keeping aspect ratio with minimum canvas loss
        //

        public static Image ForceResizeWithMinimumCanvasLoss(this Image image, int newWidth, int newHeight, bool preserveAspectRatio = true)
        {
            return ForceResizeAndCropWithMinimumCanvasLoss(image, 0, 0, newWidth, newHeight, preserveAspectRatio);
        }

        //
        // Force resize preserving aspect ratio, and then crop from given x and y pixels.
        //

        public static Image ForceResizeAndCropWithMinimumCanvasLoss(this Image image, int x, int y, int newWidth, int newHeight, bool preserveAspectRatio = true)
        {
            return image.ResizeImage(new Size(newWidth, newHeight), preserveAspectRatio).Crop(new Rectangle(x, y, newWidth, newHeight));
        }

        //
        // Force resize preserving aspect ratio, and then cropping in the center.
        //

        public static Image ForceResizeAndCropWithMinimumCanvasLoss(this Image image, int newWidth, int newHeight, bool preserveAspectRatio = true)
        {
            Image resizedImage = image.ResizeImage(new Size(newWidth, newHeight), preserveAspectRatio);

            int x = 0;
            int y = 0;

            int width = resizedImage.Width;
            x = (width - newWidth) / 2;
            int height = resizedImage.Height;
            y = (height - newHeight) / 2;

            return resizedImage.Crop(new Rectangle(x, y, newWidth, newHeight));
        }

        // 
        // Resize image
        //

        public static Image ResizeImage(this Image image, Size size, bool preserveAspectRatio = true)
        {
            int scaledWidth;
            int scaledHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                double scaleX = (double)originalWidth / (double)size.Width;
                double scaleY = (double)originalHeight / (double)size.Height;
                double scale = scaleY < scaleX ? scaleY : scaleX;
                scaledWidth = (int)(originalWidth / scale);
                scaledHeight = (int)(originalHeight / scale);

                // force minimum dimension corretions (solve trunc execeptions)
                int smallerDimension = size.Width < size.Height ? size.Width : size.Height;
                scaledWidth = scaledWidth < smallerDimension ? smallerDimension : scaledWidth;
                scaledHeight = scaledHeight < smallerDimension ? smallerDimension : scaledHeight;
            }
            else
            {
                scaledWidth = size.Width;
                scaledHeight = size.Height;
            }

            Bitmap newImage = new Bitmap(scaledWidth, scaledHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, scaledWidth, scaledHeight);
            }

            return newImage;
        }
    }
}
