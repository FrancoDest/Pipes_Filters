using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FilterPersonSearcher
    {
        public static IPicture Filter(string Picturepath) //No agregué el filtro a la interfaz de IFilter porque por lo que vi de la api CognitiveFace, trabaja con datos de tipo path
        {
            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(Picturepath);
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(Picturepath);
            
            if (cog.FaceFound)
            {
                PipeSerial filtro = new PipeSerial(new FilterGreyscale(), new PipeNull());
                IPicture image = filtro.Send(picture);
                return image;
            }
            else
            {
                PipeSerial filtro = new PipeSerial(new FilterNegative(), new PipeNull());
                IPicture image = filtro.Send(picture);
                return image;
            }
        }
    }
}