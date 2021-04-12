# GithubInformationPresenter Console Application

This is application that reads commits from github based on input arguments:
* repository owner
* repository name

After reading commits, it displays them in a console and saves to database.
When displaying and saving, we use such information:
* repository name
* username
* sha
* message
* committer

Records in database are unique - based on sha commit!

To run it exe properly, pass those arguments like this:
GithubInformationPresenter.exe |owner| |repo-name|
GithubInformationPresenter.exe przemyslaw-serwicki GithubInformationPresenter

## GithubApi
Application uses Github API calls for unauthenticated clients. As an unauthenticated client, you can make 60 requests per hour

## Database
Commits are saved to LiteDB. It's embedded, NoSQL database for .NET.
Check description here: [https://www.litedb.org/] (https://www.litedb.org/)

### Database installation
You don't have to do anything - database will be created when you run application.
When running application for the first time, database file called MyData.db will be created under program executable directory:
'bin/Debug/net5.0/MyData.db'

### Viewing database content
To work with database, please use LiteDB.Studio admin tool: [https://github.com/mbdavid/LiteDB.Studio] (https://github.com/mbdavid/LiteDB.Studio)

Just download it and run 'LiteDB.Studio.exe'
When connecting, as a file name paste path to your MyData.db file

#### IMPORTANT: Remember to run it in 'Shared' Connection Mode - second radio button of Connection Manager popup
This mode will allow you to check content of your table while application is running.

If you choose 'Direct' Connection Mode, then you might face issues if application is running in the same time
It's because Direct mode opens Database Engine in exclusive mode, so then when application will be saving data to this DB, exception can occur.

That's why 'Shared' mode is suggested if user wants to view data in the same time while console application is saving them to DB.

