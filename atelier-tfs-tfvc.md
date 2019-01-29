1 - Sur TFS créer un nouveau projet TTAuto
2 - Créer un répository TFVC et créé une Branche "Main"

3- Sur votre ordinateur connecter visual studio à Fichier > Controle de Code source (ou bien via le panel "Team Explorer")
4 - Une fois connecté, Clicker sur "Explorateur du contrôle de source"
5 - Mapper l'espace de travail (workspace) à un dossier local sur le disque
6 - A partir de l'explorateur de sources, créer un dossier "Main" sur la racine du répository
7 - Archiver les modifications
8 - Vérifier que le dossier a été bien créé sur TFS

9 - Sur TFS, dans le board du projet TTAuto, créer un nouveau "WorkItem" : "Initialize TTAuto WPF application" et notez son numéro

10 - Sur votre ordinateur, créer un projet WPF TTAuto dans le répertoire Main de votre "workspace"
11 - Apportez des modifications au projet et Archiver le: 
	Avant d'archiver Ajouter le dossier TTAuto dans le workspace via le panel "Explorateur du contrôle de code source"
	Associer le work item aux modifications. Utilisez le numéro du Work Item
	Ajouter un commentaire
	Archiver les modifications

12 - Vérifier que vos changements sont sur TFS
13 - Accédez au Board et vérifier que le workitem que vous avez créé à l'étape (9) a bien une association avec le check in que vous venez de faire


14 - Créer une build définition pour le projet TTAuto
15 - Dans les templates de projet, selectionner .Net Desktop
16 - Vérifier les étapes de build
17 - Activer l'intégration continue, dans l'onglet "Triggers"
18 - Sauvegardez et lancer la build
19 - Une fois la build terminée, vérifier qu'un Artéfact de build est présent

19' - Apportez une modification dans le fichier MainApplication.cs

20 - Créer un nouvel workitem et une nouvelle branche portant le nom de la feature
	Pr ferez une convention de nommage pour les branches, par exemple
		feature/numéro-du-work-item-nom-de-la-feature pour les features
		bug/numéro-du-work-un-texte-descriptif pour les bugs
		chore/numéro-du-work-item-texte-descriptif pour les tâches de cleanup


21 - Constatez la création d'un nouveau dossier sur le disque, ouvrir la solution créée dans le dossier portant le nom de la feature
		
22 - Dans le panel "Explorateur du contrôle de source", sélectionner la branche nouvellement créée, dans le menu contextuel cliquer sur "Afficher l'historique"
23 - Cliquer sur "Suivi de l'ensemble des modifications"
24 - Apportez des modifications sur la branche et une modification dans le fichier MainApplication.cs - même ligne que dans l'étape "19'"
25 - Comparez mes modifications entre la branche "Main" et la nouvelle branche feature

26 - Ouvrir la solution TTAuto de la branche Main et merger la feature branch and la branch main
27 - Résoudre les conflits et Archiver
28 - Supprimer la feature branch depuis TFS