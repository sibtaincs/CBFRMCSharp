using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
namespace CBFRM.AD
{
    public class LdapAuthentication
    {
        private string _path;
        private string _filterAttribute;


        public LdapAuthentication(string path)
        {
            _path = path;
        }

        public bool IsAuthenticated(string domain, string username, string pwd)
        {
            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);

            try
            {
                //Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (result == null)
                {
                    return false;
                }

                //Update the new path to the user in the directory.
                _path = result.Path;
                _filterAttribute = (string)result.Properties["cn"][0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
            }

            return true;
        }

        //public string GetGroups()
        //{
        //    DirectoryEntry searchRoot = new DirectoryEntry(_path);
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);
        //    search.Filter = "(cn=" + _filterAttribute + ")";
        //    search.PropertiesToLoad.Add("memberOf");
        //    StringBuilder groupNames = new StringBuilder();

        //    try
        //    {
        //        SearchResult result = search.FindOne();
        //        int propertyCount = result.Properties["memberOf"].Count;
        //        string dn;
        //        int equalsIndex, commaIndex;

        //        for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
        //        {
        //            dn = (string)result.Properties["memberOf"][propertyCounter];
        //            equalsIndex = dn.IndexOf("=", 1);
        //            commaIndex = dn.IndexOf(",", 1);
        //            if (-1 == equalsIndex)
        //            {
        //                return null;
        //            }
        //            groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
        //            groupNames.Append("|");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error obtaining group names. " + ex.Message);
        //    }
        //    return groupNames.ToString();
        //}





        private static string domain = "IMC";
        //sibtain  13-03-2020   
        public bool Auth(string userName, string password)
        {
            DirectoryEntry de = new DirectoryEntry(null, domain +
              "\\" + userName, password);
            try
            {
                object o = de.NativeObject;
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "samaccountname=" + userName;
                ds.PropertiesToLoad.Add("cn");
                SearchResult sr = ds.FindOne();
                if (sr == null) throw new Exception();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public string IsInRole(string userName, string role)
        {
            string s = "";
            try
            {

                role = role.ToLowerInvariant();
                DirectorySearcher ds = new DirectorySearcher(new DirectoryEntry(null));
                ds.Filter = "samaccountname=" + userName;
                SearchResult sr = ds.FindOne();
                DirectoryEntry de = sr.GetDirectoryEntry();
                PropertyValueCollection dir = de.Properties["memberOf"];
                for (int i = 0; i < dir.Count; ++i)
                {
                    s = dir[i].ToString().Substring(3);
                    s = s.Substring(0, s.IndexOf(',')).ToLowerInvariant();
                    if (s == role) return null;

                }
                return s.ToString();
            }

            catch
            {


            }
            return s.ToString();

        }
    }
}