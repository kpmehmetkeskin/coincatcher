using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TweetSharp;

namespace CoinCatcher.Utils
{
    public class TwitterWrapper
    {
        TwitterService service = new TwitterService("6PdBOnWXqEO5P89EjA771MKmr", "CvYClUh9W82FFYrmofavEZQX7X712jvH9rKzXzLlf2mvD9a26Z", "731192114592288768-urptudOkIUQAdrxc3iS5D9bJLPD4jK5", "tNZxTZr0hRlwZ5rTspPYinvtRdvNkMnMqwbI8yQCYdZIc");

        public void sendTweet(String tweet)
        {
            SendTweetOptions options = new SendTweetOptions();
            options.Status = tweet;
            options.DisplayCoordinates = false;
            TwitterStatus ts = service.SendTweet(options);
            
        }
    }
}