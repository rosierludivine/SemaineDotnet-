# SemaineDotnet

## Prerequis

Installation de Donet
Voici le liens https://dotnet.microsoft.com/en-us/download/dotnet/8.0

Verification de l'installation 

dotnet --version // verifier la version 

dotnet --list-sdks // liste des SDK installé 

## Cours 

.Net est un framwork mais pas que il est crossplateform  et open source concu par microsoft 

Voici un aperçu des technologies .NET

![ image 1]('1.png')

Dotnet core = crossplateforme 

### MVC (Modele, view, Controller )

Controlleur toute la logique de notre site 

model metier= Ces exemple la classe d'un objet 

View se qui voit sur le site va chercher ce qui doit être afficher 

dotnet new list // affichre tout les packages 

dotnet new console --use-program-main -o consoleProjet 

allez dans le dossier consoleProjet 

dotnet run 

### Les fichier 
csproj = ont dirais du xml 
git ignore bind et obj. 

installller un package 2 maniere .Net CLI ou PackageReference  

Préférence avec le .Net CLI 

### créer un projet MVC 
dotnet new list | grep mvc
avec le packages applications web ASP.NET CORE (MVC)


#### créer un projet MVC 
dotnet new mvc -o MVC 

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

    
    uNE FONCTION QUI SE RAPELLE TOUT seule ces recursible recursion 

    ### Commment apporter des fonctionnalités

    dans le main 

    var maList = new List<objet>{1,2,3,4,5,6,7,8,9};

    stocker la sum 
    var somme = Sum(maListe);

    Injecter des variables dans une chaine de caractères 
    Console.WriteLine($"Somme = {somme}" )


Nous pouvons aussi  avoir des fonctions Asynchrone quand nous avons pas de reponse de suite Api. 
    public static async Task Main(){
        await DoSomethingAsync();
    }

Initiamiser une variable a null 
Attention: 
En C# nous ne pouvons pas avoir une assigne une valeur a null 


String? test = null; 

la valeur test peut avoir la valeur string ou null 

API: 

schéma de l'api


### theme de la semaine : API 

#### creation d'un projet API 

dotnet new webapi -o BookStoreNoControllers //cree une mini api web sans controller 

dotnet new webapi --use-controllers --use-program-main -o 

csproj est egale au fichier json 

Pour faire appel au constructeur par defaut de l'héritage il faut ecrire :base ( id, ....) apres les parametres de des constructeurs des classes 

### Info Pratique 

Lors d'une modification il fait plutot arreter le CLI faire un build puis relancer.

dotnet build 
dotnet run 


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
un champs : 
public int NbPages; 


La méthode OK permet de return du code un objet Book par exemple 
return OK(books); //Voir la code du prof 