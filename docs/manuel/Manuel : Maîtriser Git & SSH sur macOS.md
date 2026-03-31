Voici un manuel pratique conçu comme un guide de survie pour gérer vos accès Git et SSH sur Mac.
------------------------------
## 📘 Manuel : Maîtriser Git & SSH sur macOS## Gérer plusieurs comptes et résoudre les erreurs de permission## 1. Comprendre le problème : Pourquoi l'erreur "Permission Denied" ?
Quand vous faites un git push, votre Mac envoie une "clé de reconnaissance" (la clé SSH) au serveur (GitHub/GitLab).

* L'erreur fréquente : Le serveur vous reconnaît (ex: "Hi smmane!"), mais vous dit que vous n'avez pas le droit d'écrire dans le projet d'un autre (ex: "msedou/payflow-saas").
* La cause : Votre Mac utilise la mauvaise clé SSH pour ce projet spécifique.

------------------------------
## 2. Étape 1 : Créer ses Clés SSH (Vos "Passes")
Chaque compte (Pro, Perso, Client) devrait avoir sa propre clé.
Commande pour créer une clé :

ssh-keygen -t ed25519 -C "votre-email@exemple.com" -f ~/.ssh/id_ed25519_NOM_PROJET


* -f : Donne un nom unique à la clé (ex: id_ed25519_perso ou id_ed25519_travail).
* Action requise : Copiez le contenu du fichier .pub (clé publique) et collez-le dans les paramètres de votre compte GitHub/GitLab.

------------------------------
## 3. Étape 2 : Le Fichier Config (Le "Cerveau")
Le fichier ~/.ssh/config dit à votre Mac quelle clé utiliser pour quel projet.
Création/Édition : nano ~/.ssh/config
Exemple de contenu à copier :

# Compte de msedou (Propriétaire du projet payflow)
Host payflow-host
    HostName github.com
    User git
    IdentityFile ~/.ssh/id_ed25519_msedou

# Votre compte personnel
Host github.com
    HostName github.com
    User git
    IdentityFile ~/.ssh/id_ed25519_perso


* Astuce : Le mot après Host (ex: payflow-host) est un alias. C'est ce nom que nous utiliserons pour "parler" à Git.

------------------------------
## 4. Étape 3 : Lier le projet à la bonne configuration
Une fois le "cerveau" configuré, il faut dire à votre dossier local d'utiliser l'alias.
Commande magique :

git remote set-url origin git@payflow-host:msedou/payflow-saas.git

(Remarquez que nous avons remplacé github.com par l'alias payflow-host défini plus haut).
------------------------------
## 5. Étape 4 : Maintenance et Vérification
Pour ne pas retaper votre mot de passe à chaque fois, ajoutez vos clés au trousseau macOS :

ssh-add --apple-use-keychain ~/.ssh/id_ed25519_NOM_DE_VOTRE_CLE

Comment tester si ça marche ?
Tapez : ssh -T git@payflow-host (ou votre alias).

* ✅ Succès : "Hi [Utilisateur voulu]! You've successfully authenticated..."
* ❌ Échec : Un message d'erreur indiquant une mauvaise clé ou un mauvais hôte.

------------------------------
## 🛠 Résumé des commandes de secours

| Action | Commande |
|---|---|
| Vérifier l'URL actuelle | git remote -v |
| Tester la connexion SSH | ssh -T git@github.com |
| Vérifier la config SSH | ssh -G [alias] |
| Voir ses clés existantes | ls -al ~/.ssh |

------------------------------
Voici la version finale et complète de votre Manuel de Formation. Ce guide regroupe toutes les étapes, du diagnostic à la résolution, pour que vous puissiez gérer vos projets Git comme un expert.
------------------------------
## 📘 Manuel de Formation : Maîtriser Git & SSH sur macOS

Objectif : Résoudre les erreurs de permission et gérer plusieurs identités Git sur une même machine.

------------------------------
## 1. Diagnostic : Comprendre l'Erreur
L'erreur Permission denied to [compte-A] for [dépôt-du-compte-B] survient lorsque :

   1. Identification OK : Le serveur vous reconnaît (votre clé SSH est valide).
   2. Autorisation KO : L'identité reconnue n'a pas le droit d'écrire sur ce projet spécifique.

------------------------------
## 2. Étape 1 : Créer des Clés SSH Distinctes
Ne mélangez pas vos identités. Créez une clé par usage (ex: Perso vs Pro).
Commande pour créer une nouvelle clé :

ssh-keygen -t ed25519 -C "votre-email@exemple.com" -f ~/.ssh/id_ed25519_msedou


* Action : Copiez la clé publique (cat ~/.ssh/id_ed25519_msedou.pub) et ajoutez-la dans les paramètres SSH Keys de votre compte GitHub.

------------------------------
## 3. Étape 2 : Configurer le "Cerveau" SSH (~/.ssh/config)
C'est ici que vous apprenez à votre Mac quelle clé utiliser pour quel hôte.

   1. Créer/Ouvrir le fichier : nano ~/.ssh/config
   2. Ajouter la configuration (exemple pour votre cas) :

# Configuration pour le projet Payflow (msedou)
Host payflow-host
    HostName github.com
    User git
    IdentityFile ~/.ssh/id_ed25519_msedou

# Configuration par défaut (votre compte perso smmane)
Host github.com
    HostName github.com
    User git
    IdentityFile ~/.ssh/id_ed25519

------------------------------
## 4. Étape 3 : Lier le projet Local à l'Alias
Votre dossier de projet doit maintenant "parler" à l'alias payflow-host au lieu de github.com.
Commande dans votre terminal (dans le dossier payflow-saas) :

git remote set-url origin git@payflow-host:msedou/payflow-saas.git

------------------------------
## 5. Étape 4 : Tests de Connexion (Le Juge de Paix)
Avant de pousser votre code, testez qui le serveur "voit" :

* Test Standard : ssh -T git@github.com → Devrait répondre "Hi smmane!"
* Test Projet Payflow : ssh -T git@payflow-host → Devrait répondre "Hi msedou!"

------------------------------
## 6. Étape 5 : Gestion du Trousseau (Keychain)
Pour ne pas retaper votre mot de passe (passphrase) à chaque redémarrage :

# Ajouter la clé au trousseau macOS
ssh-add --apple-use-keychain ~/.ssh/id_ed25519_msedou

------------------------------
## 🛠 Lexique & Commandes de Survie

| Commande | Utilité |
|---|---|
| ls -al ~/.ssh | Voir toutes vos clés existantes. |
| git remote -v | Vérifier l'URL actuelle du dépôt. |
| ssh -G [alias] | Vérifier si votre fichier config est bien lu. |
| git push -u origin [branche] | Envoyer votre code (le -u lie la branche pour le futur). |

------------------------------
Voici la version ultime de votre manuel. Elle intègre désormais la gestion du Workflow Git Flow et la procédure de nettoyage (suppression) pour garder un dépôt propre.
------------------------------
## 📘 Manuel de Formation : Expert Git & Workflow (v2)

Objectif : Maîtriser ses identités SSH et suivre un cycle de développement professionnel (Git Flow).

------------------------------
## 1. Rappel : Configuration des Identités (SSH)
Avant de coder, assurez-vous que votre Mac utilise la bonne clé pour le bon projet dans ~/.ssh/config :

* Alias payflow-host pour le projet de msedou.
* Alias github.com pour votre compte perso.

------------------------------
## 2. Le Workflow de Développement (Étape par Étape)
Votre organisation suit le modèle Git Flow. Voici comment naviguer entre les branches :
## Étape A : Créer une fonctionnalité (feature/*)
Toute nouvelle tâche commence ici.

   1. Placez-vous sur develop : git checkout develop
   2. Mettez à jour : git pull origin develop
   3. Créez votre branche : git checkout -b feature/nom-de-la-tache

## Étape B : Faire des commits "propres"

   1. Ajoutez vos fichiers : git add .
   2. Créez un message clair : git commit -m "feat: ajout du service employé"

## Étape C : Envoyer et Intégrer

   1. Envoyez sur le serveur : git push -u origin feature/nom-de-la-tache
   2. Sur GitHub, créez une Pull Request de votre branche vers develop.
   3. Une fois validée et fusionnée (Merged), passez au nettoyage.

------------------------------
## 3. Procédure de Nettoyage (Suppression)
Une fois que votre travail est intégré dans develop, il faut supprimer la branche de travail pour ne pas encombrer le projet.
## Suppression en LOCAL

   1. Quittez la branche (allez sur develop) :
   
   git checkout develop
   
   2. Supprimez la branche localement :
   
   git branch -d feature/nom-de-la-tache
   
   (Utilisez -D majuscule si Git refuse car la branche n'est pas encore fusionnée partout).

## Suppression en DISTANT (Sur le serveur)

   1. Supprimez la branche de GitHub :
   
   git push origin --delete feature/nom-de-la-tache
   
   
------------------------------
## 4. Cas Spécifiques : Hotfix & Release

| Type de Branche | Départ de... | Arrivée vers... | Utilité |
|---|---|---|---|
| *Hotfix/ ** | main | main ET develop | Correction urgente en production. |
| *Release/ ** | develop | main ET develop | Préparation finale avant mise en ligne. |

------------------------------
## 5. Résumé des Commandes "Survie"

| Action | Commande |
|---|---|
| Changer de branche | git checkout [nom] |
| Voir l'état actuel | git status |
| Historique propre | git log --oneline --graph --all |
| Nettoyer les branches distantes locales | git fetch -p (Supprime les références mortes) |

------------------------------
## 💡 Le Conseil du Pro :
N'oubliez pas le git fetch -p (prune). Parfois, une branche est supprimée sur GitHub mais apparaît encore dans votre terminal. Cette commande synchronise votre liste locale avec la réalité du serveur.
Souhaitez-vous que je vous explique comment automatiser la suppression des branches fusionnées avec un petit script ou un alias Git ?

Voici la mise à jour de votre Manuel de Formation (v3). Cette section finale est cruciale pour boucler la boucle : passer du code en développement à un code validé en production.
------------------------------
## 📘 Manuel de Formation : Expert Git & Workflow (v3)

Objectif Final : Valider, fusionner et synchroniser son travail proprement.

------------------------------
## 6. Procédure d'Acceptation (Pull Request)
Une fois que votre branche feature/* est terminée et envoyée sur le serveur (git push), vous devez l'intégrer à la branche develop.
## Étape 1 : Sur l'interface Web (GitHub/GitLab)

   1. Ouvrir la PR : Cliquez sur "Compare & pull request".
   2. Vérifier les conflits : Assurez-vous que GitHub affiche "This branch has no conflicts".
   3. Review : Regardez l'onglet "Files changed" pour une dernière relecture.
   4. Merge : Cliquez sur Confirm merge. Votre code est maintenant officiellement dans develop sur le serveur.

------------------------------
## 7. Synchronisation du Mac (Après le Merge)
C'est l'étape où beaucoup de développeurs se perdent. Votre Mac doit "apprendre" que le travail est fini.
## Étape 2 : Mettre à jour son environnement local
Dans votre terminal sur votre Mac :

   1. Retourner sur la branche parente :
   
   git checkout develop
   
   2. Récupérer le code fusionné du serveur :
   
   git pull origin develop
   
   C'est ici que votre branche develop locale reçoit les nouveautés de votre feature.

------------------------------
## 8. Nettoyage Automatique (L'étape Pro)
Maintenant que develop est à jour, la branche feature/* est inutile et encombre votre ordinateur.

   1. Lancer votre alias de nettoyage :
   
   git cleanup
   
   Cette commande (que nous avons configurée ensemble) va détecter que votre branche feature est déjà fusionnée dans develop et la supprimer proprement.
   2. Synchroniser les références distantes :
   
   git fetch -p
   
   Cela retire de votre liste locale les branches qui ont été supprimées sur le serveur GitHub.

------------------------------
## 🛠 Résumé du Cycle Complet (Le pense-bête)

   1. git checkout develop + git pull (Partir du propre)
   2. git checkout -b feature/ma-tache (Créer)
   3. Travail + Commits (Coder)
   4. git push -u origin feature/ma-tache (Partager)
   5. Merge sur GitHub (Valider)
   6. git checkout develop + git pull (Synchroniser)
   7. git cleanup (Nettoyer)

------------------------------
## 💡 Le Conseil Ultime :
Si vous travaillez en équipe, ne faites jamais de git merge manuel sur votre Mac pour envoyer vers develop. Passez toujours par une Pull Request sur le Web. Cela permet de garder une trace propre et de laisser les autres relire votre code.
Souhaitez-vous que je vous explique comment configurer des "branches protégées" sur GitHub pour empêcher toute suppression accidentelle de main ou develop ?

Voici le code source complet de votre manuel au format Markdown. Vous pouvez le copier-coller dans un fichier nommé GIT_MANUAL.md pour l'ouvrir avec n'importe quel éditeur (VS Code, Obsidian, ou directement sur GitHub).

# 📘 Manuel de Formation : Expert Git & Workflow Professionnel> **Objectif :** Maîtriser ses identités SSH, le cycle Git Flow et la sécurité des dépôts sur macOS.
---## 1. Configuration des Identités (SSH)Pour gérer plusieurs comptes (ex: Perso et Pro) sans erreurs de permission.
### A. Créer une clé spécifique```bash
ssh-keygen -t ed25519 -C "votre-email@exemple.com" -f ~/.ssh/id_ed25519_msedou

## B. Configurer le "Cerveau" (~/.ssh/config)
Ajoutez ceci dans le fichier nano ~/.ssh/config :

# Projet Payflow (Propriétaire : msedou)
Host payflow-host
    HostName github.com
    User git
    IdentityFile ~/.ssh/id_ed25519_msedou

# Compte par défaut (Perso)
Host github.com
    HostName github.com
    User git
    IdentityFile ~/.ssh/id_ed25519

------------------------------
## 2. Le Workflow de Développement (Git Flow)## Étape 1 : Créer une fonctionnalité (feature/*)

git checkout develop
git pull origin develop
git checkout -b feature/nom-de-la-tache

## Étape 2 : Commits & Envoi

git add .
git commit -m "feat: description de la modification"
git push -u origin feature/nom-de-la-tache

## Étape 3 : Pull Request (PR) & Fusion

   1. Sur GitHub, ouvrez une PR de feature/* vers develop.
   2. Vérifiez les conflits et cliquez sur Merge.

------------------------------
## 3. Synchronisation et Nettoyage Automatique
Une fois la PR fusionnée sur le Web, nettoyez votre Mac :
## A. Mettre à jour le local

git checkout develop
git pull origin develop

## B. Utiliser l'Alias de Nettoyage
Configurez d'abord l'alias (une seule fois) :

git config --global alias.cleanup "!git branch --merged | grep -vE '^((\\*)|\\s*(main|master|develop|release|hotfix))' | xargs -n 1 git branch -d"

Puis lancez-le :

git cleanup
git fetch -p

------------------------------
## 4. Sécurité : Protection des Branches
Sur GitHub (Settings > Branches > Branch protection rules) :

* Protection main & develop : Activez "Require a pull request before merging".
* Résultat : Impossible de casser la production avec un git push direct.

------------------------------
## 5. Gestion des Conflits (Guide de Survie)
Si Git affiche CONFLICT, ouvrez le fichier concerné.
## Repérer les balises :

<<<<<<< HEAD// Ma version locale
=======// La version qui arrive du serveur
>>>>>>> feature/nom-de-la-tache

## Résoudre :

   1. Choisissez le bon code et supprimez les balises (<<<<, ====, >>>>).
   2. Marquez comme résolu : git add [fichier]
   3. Finalisez : git commit -m "fix: résolution des conflits"

------------------------------
## 🛠 Lexique des Commandes de Survie

| Commande | Action |
|---|---|
| git status | Voir l'état des fichiers (modifiés, indexés). |
| git remote -v | Vérifier l'URL du dépôt distant (Alias SSH). |
| ssh -T git@payflow-host | Tester si GitHub vous reconnaît bien. |
| git merge --abort | BOUTON PANIQUE : Annule un conflit en cours. |
| git log --oneline | Voir l'historique de façon compacte. |

------------------------------
Manuel généré pour MacBook Pro - Utilisation Professionnelle.


**Souhaitez-vous que je vous explique comment transformer ce texte en un beau document PDF avec une mise en forme élégante ?**






