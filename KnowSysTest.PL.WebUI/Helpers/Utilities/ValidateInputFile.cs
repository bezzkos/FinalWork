namespace KnowSysTest.PL.WebUI.Helpers.Utilities
{
    using System.Text;

    public static class ValidateInputFile
    {
        public static bool IsImage(byte[] data)
        {
            //read 64 bytes of the stream only to determine the type
            var myStr = Encoding.ASCII.GetString(data).Substring(0, 16);
            //check if its definately an image.
            if (myStr.Substring(8, 2).ToLower() != "if")
            {
                //its not a jpeg
                if (myStr.Substring(0, 3).ToLower() != "gif")
                {
                    //its not a gif
                    if (myStr.Substring(0, 2).ToLower() != "bm")
                    {
                        //its not a .bmp
                        if (myStr.Substring(1, 3).ToLower() != "png")
                        {
                            //its not a .png
                            if (myStr.Substring(0, 2).ToLower() != "ii")
                            {
                                //its not a tiff
                                //ProcessErrors("notImage");
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}