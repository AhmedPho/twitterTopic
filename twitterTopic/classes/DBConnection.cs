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
        DataSet1TableAdapters.ErrorsTableAdapter MyErrorsTableAdapter;
        DataSet1TableAdapters.UsersTableAdapter MyUsersTableAdapter;
        DataSet1.UsersDataTable MyUsersDataTable;
        public DBConnection()
        {
            MyTweetForCategoryTableAdapter = new DataSet1TableAdapters.TweetForCategoryTableAdapter();
            MyCategoryTableAdapter = new DataSet1TableAdapters.CategoryTableAdapter();
            MyErrorsTableAdapter = new DataSet1TableAdapters.ErrorsTableAdapter();
            MyUsersTableAdapter = new DataSet1TableAdapters.UsersTableAdapter();
        }
        public Boolean IsSignUp(string TwitterID)
        {
            MyUsersDataTable = MyUsersTableAdapter.GetIDByTwitterID(TwitterID);
            if (MyUsersDataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetID(string TwitterID)
        {
            MyUsersDataTable = MyUsersTableAdapter.GetIDByTwitterID(TwitterID);
            foreach (DataSet1.UsersRow row in MyUsersDataTable.Rows)
            {
                return row.IdOfUser.ToString();
            }
            return "0";
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
                MyErrorsTableAdapter.InsertQuery(ex.ToString(), DateTime.Now.ToString());
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
                MyErrorsTableAdapter.InsertQuery(ex.ToString(), DateTime.Now.ToString());
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
                MyErrorsTableAdapter.InsertQuery(ex.ToString(), DateTime.Now.ToString());
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
                MyErrorsTableAdapter.InsertQuery(ex.ToString(), DateTime.Now.ToString());
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
                MyErrorsTableAdapter.InsertQuery(ex.ToString(), DateTime.Now.ToString());
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