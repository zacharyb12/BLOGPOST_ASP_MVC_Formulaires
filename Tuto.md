# Projet ASP MVC

## Dépendances :
- EntityFrameworkCore
- EntityFrameworkCore Design
- EntityFrameworkCore Tools
- EntityFrameworkCore SqlServer

## Structure du projet 

### Asp MVC
- Controller : Gère les actions
- Models : Contient les Modèles
- Views : Contient les vues de l'applications
- Data : Contient le context et la configuration entityFramework
- Repositories : Contient la logique 


## 1er étape: 
- Définir les modèles dans le dossier Models

## 2iem étape: 
- Définir le context et la configuration Entity
- Ajouter la configuration dans program.cs
- Effectuer une migration

## 3iem étape:
- Créer dans un dossier Repositories
- une classe et une interface ( blogRepository et IBlogRepository)
- La classe BlogRepository hérite de IBlogrepository
- Configurer l'injection de dépendances dans le program.cs

## 4iem étape:
- Injecter le context dans BlogRepository
- Implementer l'utilisation de entityFramework(CRUD)

## 5iem étape: 
- Dans le controlleur
- Injecter l'interface IBlogRepository
- Définir les actions du controlleur 

## 6iem étape: 
- Ajouter les vues
- Attention à ce que les modèles correspondent entre le controlleur et la vue