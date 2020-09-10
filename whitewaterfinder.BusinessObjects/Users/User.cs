using System;
namespace whitewaterfinder.BusinessObjects.Users
{
    /*
        from Auth0
        {
        "given_name": "Luke",
        "family_name": "Badgerow",
        "nickname": "badgerow.luke",
        "name": "Luke Badgerow",
        "picture": "https://lh3.googleusercontent.com/a-/AOh14GjodZlATJ3S5J1LkHjvyALQu7RvpTPY1xPuTnlagg",
        "locale": "en",
        "updated_at": "2020-08-04T11:54:24.540Z",
        "email": "badgerow.luke@gmail.com",
        "email_verified": true,
        "sub": "google-oauth2|102315595445931318708"
        }
    */
    
    ///<summary>
    ///This codebase is currently using Auth0 for authentication
    ///This model represents a portion of the content currently returned
    ///from the scope of the service
    ///</summary>
    public class User
    {
        public string GivenName { get; set; }
        public string FamilyName { get; set; }

        public string NickName { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Sub { get; set; }

    }
}



