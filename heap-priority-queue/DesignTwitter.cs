Twitter twitter = new Twitter();
twitter.PostTweet(1, 10); // User 1 posts a new tweet with id = 10.
twitter.PostTweet(2, 20); // User 2 posts a new tweet with id = 20.
twitter.GetNewsFeed(1);   // User 1's news feed should only contain their own tweets -> [10].
twitter.GetNewsFeed(2);   // User 2's news feed should only contain their own tweets -> [20].
twitter.Follow(1, 2);     // User 1 follows user 2.

twitter.GetNewsFeed(1);   // User 1's news feed should contain both tweets from user 1 and user 2 -> [20, 10].
twitter.GetNewsFeed(2);   // User 2's news feed should still only contain their own tweets -> [20].
twitter.Unfollow(1, 2);   // User 1 unfollows user 2.
twitter.GetNewsFeed(1);
return 0;

public class Twitter {

    Dictionary<int, HashSet<int>> followersMap;
    Dictionary<int, List<Tuple<int, int>>> tweets;
    int time;

    public Twitter() {
        followersMap = new Dictionary<int, HashSet<int>>(); 
        tweets = new Dictionary<int, List<Tuple<int, int>>>();
        time = 0;
    }
    
    public void PostTweet(int userId, int tweetId)
    {
        if(!tweets.ContainsKey(userId))
            tweets[userId] = new List<Tuple<int, int>>();
        tweets[userId].Add(new Tuple<int, int>(time, tweetId));
        this.time++;
    }
    
    public List<int> GetNewsFeed(int userId) {
        var res = new List<int>();
        var heap = new PriorityQueue<int, int>(Comparer<int>.Create((x,y) => y.CompareTo(x)));

        if(followersMap.ContainsKey(userId))
        {
            foreach(var followee in followersMap[userId])
            {
                if (followee == userId) continue;

                if (tweets.ContainsKey(followee)) 
                {
                    foreach(var tweet in tweets[followee])
                        heap.Enqueue(tweet.Item2, tweet.Item1);
                }
            }
        }

        if (tweets.ContainsKey(userId))
        {
            foreach(var tweet in tweets[userId])
                heap.Enqueue(tweet.Item2, tweet.Item1);
        }

        while(heap.Count > 0 && res.Count < 10)
            res.Add(heap.Dequeue());

        return res;
    }
    
    public void Follow(int followerId, int followeeId) {
        if(!followersMap.ContainsKey(followerId))
            followersMap[followerId] = new HashSet<int>();
        followersMap[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(followersMap.ContainsKey(followerId))
            followersMap[followerId].Remove(followeeId); 
    }
}
