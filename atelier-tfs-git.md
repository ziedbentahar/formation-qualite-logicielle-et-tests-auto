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

12 -
