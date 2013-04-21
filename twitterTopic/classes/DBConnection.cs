using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twitterTopic.classes
{
    public class DBConnection
    {
        DataSet1TableAdapters.TweetForCategoryTableAdapter MyTweetForCategoryTableAdapter;
        DataSet1TableAdapters.CategoryTableAdapter MyCategoryTableAdapter;
        public DBConnection()
        {
            MyTweetForCategoryTableAdapter = new DataSet1TableAdapters.TweetForCategoryTableAdapter();
            MyCategoryTableAdapter = new DataSet1TableAdapters.CategoryTableAdapter();
        }
        public Boolean AddTweetInDB(string tweet, string dataOfTweet, string fromUser, string idOfTweet)
        {
            try
            {
                MyTweetForCategoryTableAdapter.InsertQuery(tweet, dataOfTweet, fromUser, idOfTweet);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Boolean AddCategory(string categoryName)
        {
            try
            {
                MyCategoryTableAdapter.InsertQuery(categoryName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean EditCategory(int IdOfCategor, string NewName)
        {
            try
            {
                MyCategoryTableAdapter.UpdateQuery(NewName,IdOfCategor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean DeleteCategory(int IdOfCategor)
        {
            try
            {
                MyCategoryTableAdapter.DeleteQuery(IdOfCategor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean LinkListToCategory(string ListID, string CategoryID)
        {
            try
            {
                MyCategoryTableAdapter.UpdateQueryForList(ListID, int.Parse(CategoryID));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

    }
}
/*
try
            {
               return true;
            }
            catch (Exception ex)
            {
                return false;
            }
*/