
# Tarot Scoreur

[![Build Status](https://codefirst.iut.uca.fr/api/badges/jordan.artzet/SFJJ-TarotScoreur/status.svg)](https://codefirst.iut.uca.fr/jordan.artzet/SFJJ-TarotScoreur)
[![Bugs](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=bugs&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)
[![Code Smells](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=code_smells&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)
[![Coverage](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=coverage&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)
[![Duplicated Lines (%)](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=duplicated_lines_density&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)
[![Maintainability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=sqale_rating&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)
[![Quality Gate Status](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=alert_status&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)
[![Reliability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=reliability_rating&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)
[![Security Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=security_rating&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)
[![Technical Debt](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=sqale_index&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)
[![Vulnerabilities](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=SFJJ-TarotScoreur&metric=vulnerabilities&token=caad45465962b160185130fecf36892788f91e2c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=SFJJ-TarotScoreur)


<!-- Présentation -->
\
The Tarot Scoreur application allows during your tarot games to automatically count the points of all the players in the game. With this application you can play online with your friend or play locally at your home !

## Installation

### Launch console app

1. Move into `Sources/TarotDb`
2. Create migration with the following command
   ```
   dotnet ef migrations add myFirstMigration
   ```
3. Move into `Sources/Tests/FT_TarotDb`
   ```
   cd ..\Tests\FT_TarotDB\
   ```
4. Create or update database with the following command
   ```
   dotnet ef database update --project ..\..\TarotDB\
   ```
5. Run project `FT_TarobDb` with the following command
   ```
   dotnet run
   ```

## **Postman client**

To configure a Postman client for the REST API and Gateway, follow these steps:

1. Install Postman by following the instructions on the official <a href="https://www.postman.com/downloads/" target="_blank">Postman</a> website.

2. Open Postman and click on the "New" button on the top left to create a new request.

3. Select the type of request you want to make (GET, POST, PUT, etc.).

4. Enter the URL of the REST API or Gateway in the URL bar, for example :  
   - REST API :
      ```
      https://codefirst.iut.uca.fr/containers/jordanartzet-tarot-rest-service/api/v{version}/users
      ```
   - Gateway :
      ```
      https://codefirst.iut.uca.fr/containers/jordanartzet-tarot-gateway-service/gateway/v{version}/users
      ```

5. Replace {version} or any other parameter with its value. In our case it will be 1.

   - Create a variable in Postman by going to Environments. You can then use this variable to replace the parameters in the API addresses, as follows:

   - REST API: 
      ```
      https://codefirst.iut.uca.fr/containers/jordanartzet-tarot-rest-service/api/v{{version}}/users
      ```
   - Gateway API: 
      ```
      https://codefirst.iut.uca.fr/containers/jordanartzet-tarot-gateway-service/gateway/v{{version}}/users   
      ```
   - This will allow you to change the value of the "version" variable from within the environment without having to modify the requests individually.

6. Click the "Send" button to send the request.

7. The response will be displayed in the "Response" section below.

8. You can save this request by clicking "Save" to use it later.

9. You can now use Postman to make requests to the REST API and the Gateway. Note that you may need to add additional headers and options depending on the API documentation.

## **Examples**

<!-- Mettre des images de l'application par le future -->
<img src="./Documentation/images/Accueil_Connecte.svg" height="400">
<img src="./Documentation/images/Lancer_Partie.svg" height="400">
<img src="./Documentation/images/Ajouter_Manche.svg" height="400">
<img src="./Documentation/images/Classement_Joueurs.svg" height="400">
<img src="./Documentation/images/Profil.svg" height="400">

Here is some examples of what you can do with the application.  
- You can see who you are and your current games 
- You can start or create a new game.
- You can add a new hand to your game.
- You can see the ranking of all the players.
- You can see your profile.

For more examples, please refer to the [Wiki](https://codefirst.iut.uca.fr/git/jordan.artzet/SFJJ-TarotScoreur/wiki/Tarot-Scoreur)


## Features

<!-- Qu'est ce que l'on peut faire avec l'application
     Présentation de toutes les fontionnalités -->

### Online mode

This mode allow you to play online and share your scores and achievements of all the game you play.

### Local mode

This mode allow you to play at your home and add your friends on your phone. Enjoy playing your tarot games with your friends at home !

## Usage

To learn how to use our application you can read the [user manual](https://codefirst.iut.uca.fr/git/jordan.artzet/SFJJ-TarotScoreur/wiki/Tarot-Scoreur-en) on the wiki.
 

## Questions

For questions and support ask [here](#).

## Contributors

| Name            | Role                                                                            |
|-----------------|---------------------------------------------------------------------------------|
| Samuel Sirven   | Best manager of all times                                                       |
| Florent Marques | Developer who develop the player, user and ranking features (like the football) |
| Julien Themes   | Developer who develop the management of the games                               |
| Jordan Artzet   | Best developer of all times                                                     |



