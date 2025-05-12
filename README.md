This is C# (Windows Forms) application that models football club management system.
A football club is defined by its name, year of establishment, phone number, and email address. The club can have multiple sponsors. 
For each sponsor, the club signs a separate contract. Each contract is characterized by the number of clauses, total value, date of signing, and expiration date. 
Sponsors are described by their name, phone number, and email address.

The club consists of multiple teams, each identified by a unique ID and team name. Every team has a roster of players. 
Each player is characterized by a unique national identification number (JMB), first name, last name, jersey number, and height. 
For each player, season-level records are maintained, including the team they played for during that season. 
These records include the position played, number of matches played, number of goals, number of assists, contract start date, and contract end date.
A season is described by a unique identifier (season name), start date, and end date. Each team has a coach. 
Coaches are identified by a unique national identification number (JMB), first name, last name, email, years of experience, and number of assistants. 
Season-level data is also tracked for each coach, indicating which team they coached and the contract duration for that season.
During a season, teams compete in a league. A league is characterized by its name, the country where the matches are played, the number of participating teams, and a coefficient. 
A team may compete in different leagues across seasons, depending on promotions or relegations. 
Season-level team statistics are also recorded, including league position, number of matches played, wins, losses, draws, points earned, goals scored, and goals conceded.
Each team conducts training sessions at a stadium. A stadium is defined by its name, capacity, and year of construction.


The system supports two types of user accounts: Administrator and Standard User.
Administrators have elevated privileges, including the ability to view, create, delete, and update user accounts. 
Standard Users can view basic user information (such as name, surname, username, and account status), but the buttons for performing operations like adding, deleting, or updating users are disabled for them.

The application also supports internationalization, offering both Serbian (default) and English languages. The logged-in user can change the language via a ComboBox in the “Settings” tab. 
The selected language is applied to all forms and controls throughout the application.

The system includes theme customization. Three visual themes are available: Blue (default), Red, and Green. 
Each theme is associated with a distinct font style. Users can choose a theme via a ComboBox in the “Settings” tab. 
The selected theme is saved and automatically applied the next time the user logs in.
