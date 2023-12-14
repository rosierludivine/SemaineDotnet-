# SemaineDotnet

## Prerequis

Installation de Donet
Voici le liens https://dotnet.microsoft.com/en-us/download/dotnet/8.0

Verification de l'installation 
```C#
dotnet --version // verifier la version 

dotnet --list-sdks // liste des SDK installé 
```
## Cours 

.Net est un framwork mais pas que il est crossplateform  et open source concu par microsoft 

Voici un aperçu des technologies .NET

![ image 1]('1.png')

Dotnet core = crossplateforme 

### MVC (Modele, view, Controller )

Controlleur toute la logique de notre site 

```C#
model metier= Ces exemple la classe d'un objet.

View se qui voit sur le site va chercher ce qui doit être afficher 

dotnet new list // affichre tout les packages 

dotnet new console --use-program-main -o controleDotnet 

allez dans le dossier consoleProjet 

dotnet run 
``````

### Les fichier 

csproj = ont dirais du xml 
git ignore bind et obj. 

installller un package 2 maniere .Net CLI ou PackageReference  

Préférence avec le .Net CLI 

### créer un projet MVC 
```c#
dotnet new list | grep mvc
``````
avec le packages applications web ASP.NET CORE (MVC)


#### créer un projet MVC 
```C#
dotnet new mvc -o MVC 
``````
##### Fichier MVC 

Le fichier sln: 
Sln solution permet de lister les projets sa ressemble au format ymal. 
Nous pouvons y voir notre version de visual studio ainsi que la version minimum. Possible qu'il ne soit générer par la commande. 

Le fichier csproj: 

Installation du Microsoft.EntityFrameworkCore 

Le fichier wwwRoot 
Tout les fichier static qui seront accessible, installation des librairies . 

A retenir: 

Toute les assets a static doivent être placer dans wwwroot, 

    
    Une FONCTION QUI SE RAPELLE TOUT seule ces recursible recursion 

    ### Commment apporter des fonctionnalités

    dans le main 
```C#
    var maList = new List<objet>{1,2,3,4,5,6,7,8,9};

    stocker la sum 
    var somme = Sum(maListe);

    Injecter des variables dans une chaine de caractères 
    Console.WriteLine($"Somme = {somme}" )
``````

Nous pouvons aussi  avoir des fonctions Asynchrone quand nous avons pas de reponse de suite Api. 
  ```C#
    public static async Task Main(){
        await DoSomethingAsync();
    }
```

Initiamiser une variable a null 
Attention: 
En C# nous ne pouvons pas avoir une assigne une valeur a null 

```C#
String? test = null; 
```

la valeur test peut avoir la valeur string ou null 

API: 

schéma de l'api


### theme de la semaine : API 

#### creation d'un projet API 

```.NET
dotnet new webapi -o BookStoreNoControllers //cree une mini api web sans controller 

dotnet new webapi --use-controllers --use-program-main -o 
``````

csproj est egale au fichier json 

Pour faire appel au constructeur par defaut de l'héritage il faut ecrire :base ( id, ....) apres les parametres de des constructeurs des classes 

### Info Pratique 

Lors d'une modification il fait plutot arreter le CLI faire un build puis relancer.

```
dotnet build 
dotnet run 
```

### Création d'un controleur en API 

## Créer une class C#

 **Les utilisation d'une property et d'un champs ce fait de la même manière. Sur une propriétés il est plus simple de changez sont accesseurs get ou set. peut etre que Get donc en lecture seul.** 

une proprety : 
public sting title { get, set};
public sting Author;

var myBook = new Book("The Great Gatsby","F.Scott Fitzgerland");
myBook.Title = "The Great Gatsby"; 
myBook.Author = "F.Scott Fitzgerland"; 


**Les champs non pas d'accesseurs de getteurs et de setteurs.**
```C#
un champs : 
public int NbPages; 
```

La méthode OK permet de return du code un objet Book par exemple 

```C#
return OK(books); //Voir la code du prof 
```

### Les erreurs a éviter 

erreur 400:  bad request 
La structure de l'objet ne revoit pas ce que nous attendons 
exemple nous devons avoir un livre mais nous nous envoyer du pain

this en orientation objet:


### A quoi correspond this 
 this designe la classe dans laquelle on se trouve ( en cours d'éxéceution). 

 # Note Mardi 

### SQLite 

Pour le lancez il faut ouvrir un terminal et ecrire 

```
sqlite3
```

Pour selectionner une base de données déjà existante ".open nomdelatable" .

Lister une tables ".tables"

Apparitions des tables dans notre base de données ".schema nomTable"

#### Consigne 


- Créer une base de données avec une table
- Insérer des données dans la table
- Faites des requêtes de sélection sur la table
- Faites des requêtes de mise à jour sur la table
- Faites des requêtes de suppression sur la table
- Faites des requêtes de création de table
- Faites des requêtes de suppression de table 

SQLITE sgbd  differente des autres mongi db maria car elle ont besoin du chemin l'adresse ces une URL c'est a dire que c'est sur un serveur. Tandis que SQLite 

##### SQLite 

 **SQLite** est un SGBD qui est adapté au environnement embarquer (exemple: téléphone, avion, voiture, bus, toute les systeme sans internet). Vu que ça n'a pas besoin de serveur. 

 **Différence avec les autres SGBD**


**For Windows**

Comment nous l'avons installer? 
Nous sommes allez sur le site *https://www.sqlite.org/download.html*

Aller dans la parti *Precompiled Binaries for Windows*. 

### Entity Framework Core/ Entity Framework 8

Entity Framework Core est un ORM (Object Relational Mapper) qui permer de manipuler des donnes relationelles en utilisant des objes .NET.

Avec EF, nous allons à partir des entités( classes ) définir dans notre code, générer la base de données correspondante. Noous allons également pouvoir effectuer des opérations CRUD (Create, Read, Update, Delete) sur ces entités.

Chaque étapes de la génération de la base de données est appelé migration. Une migraation est un ensemble de modifications apportéses à la base de données. Chaque migrations est associées à un nuléro de version. Lorsque nous appliquons une migrations, nous mettons  à jour la base de dinnées avec les modofications de la migration. 

SGBD le plus conseuller SQLserveur et le plus utiliser postgres. SQLServeur lourd et achat d'une licence. 

Nous allons avoir besoin de trois packages NuGet pour utiliser Entity Framework Core:

- pour la base de données sqlite: Microsoft.EntityFrameworkCore.Sqlite
- Pour EF Core : Microsoft


dotnet tool install --global dotnet-ef

mettre a joour la base de donnée,il faut bien ce trouver dans le projet ou il y a le dbcontext

migration 
dotnet  ef migrations add InitialMigration 

mettre a jour la base de donnes 
dotnet ef database update 

### Mercredi 

#### Entry 

permet te tracker les changement sans les mettres dans la base de données 

```C#
_dbContext.Entry(bookToUpdate).State = EntityState.Modified
```

Propriété Static vu qu'il n'y a pas d'instance. 
En c# EntityState et une énummération on utilise cette structure pour stocké les donnée dans un certains ordre. 

Code 204 Modification a bien eu lieu mais a rien a afficher 

DTO Data tansfert Object 

Mettre les DTO dans le fichier models 

Installation de auto mapper 

Faire un DTO que pour le get 

task wrapper pour les opération async 
Actionresult permet de structurer une reponse http
Auto mapper
Path update partiel 
Annotation de decorration  

```C# 
[MaxLength(200)]
```

models states 

```C#
return BadRequest (ModelState);
```


gerer l'authent  sign in management 
role role management
user user management 

spa **single page application**

jwt token jeton pour eviteer d'avoir le login et mot de passe visible 
iat issu at issu a 

ces le nom de la class pour faire les migrations 

a installer Microsoftt.AspNetCore.Identity.entityFramework 

Comment gérer l'auth
userDbContext  // couche user application 

pour proteger une route il faut mettre [Authorize] au dessus de la route 
pas besoin d'autorisaton 