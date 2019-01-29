# Atelier Git sous TFS

1 - Installer un client Git: Quelques recommendations sur windows: SourceTree, GitKraken
  * Si vous êtes familiers avec TortoiseSVN, TortoiseGit garanti une transition douce de SVN vers GIT
  
2 - Une fois installé, assurez-vous que git est installé dans le path: Allez sur l'invite de commande et tapez `git`

3 - Créer un répository local git: Sur l'invite de commande créer un nouveau dossier et *cd* dans ce dossier. Tapez `git init`

4 - Constatez le dossier *.git* créé. 

5 - Dans ce dossier créer une nouvelle application WPF "TTAuto" et compiler l'application

6 - Dans l'invite de commande tapez `git status`

7 - Nous ne souhaitons pas archiver certains fichiers tels que les fichiers binaires et le contenu des repertoires `bin` et `obj`: créer un fichier .gitignore

8 - Dans fichier .gitignore declarer les fichiers et dossiers à exclure de l'archivage, 
  * Le site https://www.gitignore.io/ propose une liste exhaustive de fichiers .gitignore selon les environnement de développements et selon les languages de programmation

9 - Ajouter les fichier dans l'index git: `git add .`

10 - archiver les changements dans le repository local: `git commit -m "message"`


Notes: Les différents éléments de travail sous git


                                     workspace -> index -> repository local -> repository distant


9 - Sur TFS, créer une nouveau répository git TTAuto, ce répository sera vide. Notez les instruction de `clone et de configuration du répository en local

10 - Sur votre machine, suivez les instructions pour *pousser* un repository local vers un répository distant (hosté dans TFS dans notre cas):
  * `git remote add origin https://{url de votre repository git créé sur tfs}`
  * `git push` 
  
L'instruction `git remote add`: configure le repository local en lui définissant un répository "origin" distant

11 - Créer une nouveau WorkItem dans le projet TFS, notez le numéro du WorkItem

12 - Ouvrir la solution TTAuto sous visual studio et apportez des modifications au projet

13 - Dans le panel "Team explorer" ouvrir le menu déroulant et selectionner "Modifications"

14 - Dans le message, tapez le nuémo du work item précédé par #. #42 par exemple

15 - Clickez sur "Validez-tout", "Synchronisez" et puis sur "Poussez", allez sur TFS et vérifier que les nouveaux changements sont pris en compte. Vérifiez également que le workitem est associé aux nouveau changements de code

16 - sur TFS créer un nouveau workitem. Sur visual studio créer une nouvelle branche dédiée à cette feature. 
Vous pouvez également créer une banche avec cette commande `git checkout -b <le nom de la branche>`

Note : Il est préferable de respecter une convention de nommage des branches

17 - Allez sur TFS dans le repository et constacter le texte qui vous invite à créer une pull request. Cliquez sur ce lien.

18 - Remplir les champs de l'écran "New Pull Request" et renseigner un "Reviwer"

19 - Completez la pull request: Cette action va merge la feature branch dans master

20 - Sous TFS allez dans l'écran de configuration du projet et cliquez sur Repos > policies et configurer les politiques de branches: 
Définissez une politique adéquate à vos pratiques de développement

21 - Retourner dans la solution et créer un nouveau tag "0.1", poussez le tag

22 - Configurer une nouvelle définition de build pour le projet


