export interface User {
    given_name: string;
    family_name: string;
    nickname: string;
    name: string;
    picture: string;
    locale: string;
    updated_at: string;
    email: string;
    email_verified: boolean;
    sub: string;

}


/*
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