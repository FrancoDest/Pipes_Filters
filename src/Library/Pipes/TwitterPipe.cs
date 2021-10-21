using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using TwitterUCU;


namespace CompAndDel.Pipes
{
    public class TwitterPipe : IPipe
    {
        public TwitterPipe(string Twittermessage,string Nametogo)
        {
            TwitterImage twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(Twittermessage,Nametogo));
        }
        public IPicture Send(IPicture picture)
        {
            return this.Send(picture);
        }
    }
}