using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using System.Collections.Generic;
using TwitterUCU;
using CognitiveCoreUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parte 1 y 2
            List<IPicture> ListFilterimage = new List<IPicture>();
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");
            string guardado = (@"Cerveza.jpg");
            string guardado2 = (@"luke.jpg");

            PipeSerial filter3 = new PipeSerial(new FilterNegative(), new PipeNull());
            IPicture  image1 = filter3.Send(picture);
            ListFilterimage.Add(image1);

            PipeSerial filter2 = new PipeSerial(new FilterGreyscale(), filter3);
            IPicture image2 = filter2.Send(picture);
            ListFilterimage.Add(image2);
            
            PipeSerial filter1 = new PipeSerial(new FilterBlurConvolution(), filter2);
            IPicture image3 = filter1.Send(picture);
            ListFilterimage.Add(image3);

            IPicture Finalimage = ListFilterimage[ListFilterimage.Count - 1]; 
            provider.SavePicture(Finalimage,guardado);

            //Parte 3
            TwitterPipe Tweet = new TwitterPipe("Joacoooo",guardado);

            //Parte 4
            IPicture luke = FilterPersonSearcher.Filter(guardado2);
            IPicture chelliña = FilterPersonSearcher.Filter(guardado);

            provider.SavePicture(luke,@"Lucas.jpg");
            provider.SavePicture(chelliña,@"Cerveciña.jpg");

        }
    }
}
