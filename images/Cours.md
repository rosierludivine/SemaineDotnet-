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