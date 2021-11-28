# .NETII-FinalProject
A Magic the Gathering project using a MSSQL database and .NET framework

**11/8/21**
Finished the user login and signup. On login, the user's email is passed through checking for their roles and updating the Mainwindow accordingly. On signup, a new user
is placed in the DB and then logged in using those credentials. 

**11/14/21**
Finished the fake card accessor and manager along with the tests associated with them. Currently, the user does not have a way to view the cards 
on separate "pages" unless they change the code in the MainWindow. Will be the next update along with the actual CardAccessor being finished.

**11/21/21**
Finished the retrieve_cards_by_page. Able to retrieve cards from the database (currently not enough cards to select by page and the window does not currently support several pages yet). The next update will be to be able to change which cards are retrieved by which page is currently selected.

**11/26/21**
Cleaned up the retrieve_cards_by_page and am able to separate the search results by page. The application is now able to limit the cards shown by page number and will show up to 20 cards. The next update will show all the decks on the Decks tab.

**11/27/21**
Completed the deck and deck cards retrieval. The user is now able to retrieve all decks (that are *public*) and the cards related to those decks. The next update will show all matches in the matches tab.