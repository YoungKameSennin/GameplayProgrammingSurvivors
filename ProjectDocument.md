# Gameplay Programming Survivors

## Summary

Inspired by
[Vampire Survivors](https://en.wikipedia.org/wiki/Vampire_Survivors), our game
is a roguelike shoot 'em up where the player takes on the role of a senior
Computer Science student who is enrolled in a course named Gameplay Programming
at the University of California, Davis. The enemies they will battle include
class exercises, assignments, and our teaching team, which includes the
respective Professor Joshua McCoy and Teaching Assistant Kyle Mitchell.

## Project Resources

[Web-playable version of your game.](https://botlinyq.github.io/ECS179FinalWebGL/)  
[Trailor](https://www.youtube.com/watch?v=xlWIoJllBno)  
[Press Kit](https://raw.githack.com/YoungKameSennin/GameplayProgrammingSurvivors/main/demo-presskit/build/product/index.html)  
[Proposal: Gameplay Programming Survivors: Initial Plan](https://docs.google.com/document/d/1IPP3eO-8G6_07iIUYMxNZpIdNCNNcWwMxNymM5PuU4M/edit?usp=sharing)

## Gameplay Explanation

This game is a class Vampire Survivor game, click start at the start screen to
enter the game. When you enter the game, you will see a player character, you
can use WASD to move, and the character will automatically attack the nearest
enemy. Enemies will drop blue gems, which are experience points, and the
character can move to the gems to pick up experience and upgrade. When
upgrading, players can see three random draws to obtain skill upgrades to
improve the player's attack or defense, and players need to choose a skill from
these three options.

To clear the game, the player must defeat two bosses: the TA and the Professor.
The TA will be generated after the player reaches level 10, and the final boss,
the Professor, will appear once the TA is defeated.

The optimal gameplay strategy, according to our current balancing, is to
continuously select the 'Merry Go Round + 2' upgrade option, which empowers the
player with two additional flying bullets that orbit the player and severely
damage enemies. Another key upgrade option is 'Get Shield Enhance,' which
increases the shield's maximum capacity and improves fault tolerance.

# Main Roles

-   Producer: Hauser Zhou
-   Physics/Movement: Shijie Wei
-   Game Logic: Wei Shao
-   Animation and Visuals: Lin Yiqiao
-   User Interface and Input: Dongxian Li

Your goal is to relate the work of your role and sub-role in terms of the
content of the course. Please look at the role sections below for specific
instructions for each role.

Below is a template for you to highlight items of your work. These provide the
evidence needed for your work to be evaluated. Try to have at least four such
descriptions. They will be assessed on the quality of the underlying system and
how they are linked to course content.

_Short Description_ - Long description of your work item that includes how it is
relevant to topics discussed in class.
[link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
_Procedural Terrain_ - The game's background consists of procedurally generated
terrain produced with Perlin noise. The game can modify this terrain at run-time
via a call to its script methods. The intent is to allow the player to modify
the terrain. This system is based on the component design pattern and the
procedural content generation portions of the course.
[The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally
use the template when necessary and appropriate.

## Producer

_Game Structure & Team Coordinate_ - As producer, I provided the basic concepts
of the game, as well as organizing communication and collaboration between group
members. Our group members communicate and collaborate with each other through
discord. I usually work out a time with them in our group chat and work on it
together. And of course contributing to the code for the game as a whole.

_Repository Management_ - I had the group all create a github document to keep
track of roughly what work was performed on each commit.While we did a lot of
work later on, and very many quick fixes, before the final presentation, and
there were gaps in the documentation, I think it was a good way to help us
understand other people's work, and make it easier to do our own work based on
others'.

_TileMap_ - I created the initial TileMap for the project to make it easy for
our members to have an easy base to start working on, and also set up collisions
for the edges to avoid players walking out of the map. This one also became our
final map for the background of the game.And also get the free resource in Unity
asset store. ![image](https://hackmd.io/_uploads/ByXtS5cCa.png)
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/27ff6947bc13545eaf9927c43a1e6109d2c0ac9f/GPSurvivors/Assets/Tilemap/New%20Palette.prefab#L1
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/27ff6947bc13545eaf9927c43a1e6109d2c0ac9f/GPSurvivors/Assets/Tilemap.meta#L1

_Combat System_ - I designed the simple combatsystem for the game and wrote the
scripts for it.The relevant script I wrote is： APbullet.cs(Penetrating bullet
penetration function and collision detection, and off-camera disappearance
function),also the prefab.
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/APbullet.cs#L5
![image](https://hackmd.io/_uploads/rki0c9cAp.png) Bullet.cs(Allows bullets to
automatically track set enemies, collision determination, and damage
determination)
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/Bullet.cs#L5
![image](https://hackmd.io/_uploads/Sy0AUc9R6.png) Merry.cs(Collision logic and
destruction logic for rotating projectiles) MerryGoRound.cs(Charging logic and
generation of rotating projectiles and firing logic),also the prefab
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/Merry.cs#L5
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/MerryGoRound.cs#L5
![image](https://hackmd.io/_uploads/rk_v95c0T.png) PlayerShooting.cs(Allows the
player to autofire and attack the nearest enemy, as well as fire different types
of projectiles) Shield.cs(Shield and enemy collision logic)
ShieldManager.cs(Allows the player to generate shields to resist damage, and has
the logic of recharging for a period of time after the shield breaks)
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/PlayerShooting.cs#L6
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/Shield.cs#L5
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/ShieldManager.cs#L5
![image](https://hackmd.io/_uploads/SJ4Mp59Cp.png) TaBullet.cs(Same
functionality as Bullet.cs except that the damage object is modified to be the
player)
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/TaBullet.cs#L5
![image](https://hackmd.io/_uploads/HyYt3950p.png)

_PlayerStatusManager.cs_ - This script implements the ability for players to
upgrade and the experience required to do so increases by a factor over time.
Also this script allows the player to get three random upgrade options after
upgrading and manages all of the player's skill levels and stats in this
script.The code in this script that interacts with the UI is done by other group
members.
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/PlayerStatsManager.cs#L14

_UIExperienceBar.cs_ - This script implements the ability for the player's
experience progress to be displayed on the overhead slider. Among other things,
the UI for the slider was created by me. Other functions such as displaying
levels and times are done by other group members.
https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/UIExperienceBar.cs#L7
![image](https://hackmd.io/_uploads/HyZCeo5AT.png)

_Setting The Layer Matrix_ - I create different layers to make it easier to
manage physical collisions between different objects through a matrix.
![image](https://hackmd.io/_uploads/Hy-jWi90p.png) All those above are based on
the topic component design pattern, the procedural content generation, factory
pattern, game combat algorithms, Unity structures from the course. When I worked
as a producer, I was responsible for the game as a whole and had a great time
working with the group. And also a lot of fun.

## User Interface and Input - Dongxian Li

**Describe your user interface and how it relates to gameplay. This can be done
via the template.** **Describe the default input configuration.**

### Game Start Menu

![Screen Shot 2024-03-21 at 11.28.42 PM](https://hackmd.io/_uploads/H1USLsq06.png)

Typically, when we start to play a game, the first screen we load is the game
start menu, or sometimes we call main menu, so we first designed this user
interface. This UI contains the game name - GP Survivors, the play game button,
and the setting button. For the play game button, I set the value of alpha as
zero to make it completely transparent with the background image. And then,
since we already have the GamePlay scene, I create a GameStart scene
individually. When the button is clicked, it will call the corresponding
function from the
[GameStart](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/Gam
eStart.cs#L1-L12) script, then it will lead us to the GamePlay scene to start to
play the game. To make sure the button work properly, I added the button
function to the OnClick() which I attached the picture below.

![Screen Shot 2024-03-22 at 12.35.05 AM](https://hackmd.io/_uploads/HkWaEnqCT.png)

Moreover, my teammate Wei Shijie and I designed and added the background image
and font style of the game name to make the user interface look more beautiful.

### Level Up

![Screen Shot 2024-03-22 at 12.43.33 AM](https://hackmd.io/_uploads/HJDT83q06.png)

The level up UI is the most frequent UI page that would apper during the game.
In our design, each button would randomly have a skill increasing. Meanwhile,
the corresponding name of the skill would show on the button. When any button is
clicked, it will go back to the game and the level would have been incremented.
Therefore, I created this interface with the name and three buttons. In the
early stage of our progress, we don't have the skills yet, so I only set up a
OnClickLevelUp() function to be called in PlayerController script. When the
player clicks any of those three buttons, it will go to the next level anyways
without any name change. After having those different skills, my teammate Shao
Wei took over and implemented the functions to make it work perfectly.

### Game Over

![Screen Shot 2024-03-22 at 1.24.06 AM](https://hackmd.io/_uploads/rJnHgT5RT.png)

When the user character's blood is below 0, the game is over, and this game over
screen would pop up. It was created with the text of game over and a restart
button. Everything would be reset to the original position to start the game by
clicking the restart button. The game logic of this screen is when the
[current health](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/PlayerController.cs#L78)
<= 0,
[GameOverUI](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/PlayerController.cs#L80)
would be enabled. And then the
[OnClickRestartButton()](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/PlayerController.cs#L80)
in PlayerController script was implemented. The GameOverUI would be disabled
after clicking the restart button.

### Game Win

![Screen Shot 2024-03-22 at 1.47.52 AM](https://hackmd.io/_uploads/rJDRH6q0p.png)

Similar to the GameOverUI, the GameWinUI was created in the same way with the
text of Congratulations and the play again button. When the big boss which is
[the prof](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/PlayerController.cs#L84)
was defeated,
[GameWinUI](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/PlayerController.cs#L86)
will be enabled to show you that you have won the game. If the player decides to
play one more time, simply clicking on the play again button, then the
[OnClickGameWin()](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/PlayerController.cs#L113-L117)
in PlayerController script would disable the GameWinUI, and the game would reset
to the original position as well.

### Input

The input system is simply using the four different direction arrow keys or the
A, W, S, D keys to control the player character to move toward any location on
the map and the mouse to click the different buttons for different purposes.

## Movement/Physics - Shijie Wei

### Player Movement

The player is able to move up, down, left, and right around the 2D platform by
using the W, A, S, and D keys or the arrow keys. This movement is achieved in
the scribe `PlayerController` by getting the direction from the user input,
[the key press detection](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/PlayerController.cs#L57),
and giving the player object a velocity to the inputted direction. Base on the
direction inputed, the player will be
[flipped to it's mirror image horizontally](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/PlayerController.cs#L65),
facing the same direction as the user input.

### Enemy Movement

The enemies are always moving toward the player's position once they are
spawned/generated until they get destroyed. In the script `EnemyController`,
each enemy's movement will start by
[calculating the direction using the spawn position and player position](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/EnemyController.cs#L54),
and then give the enemy object a velocity. The enemies were able to flip
horizontally relative to the player's y-axis, making sure the enemy was always
facing the player while the player was moving. We decided not to add the
rotation to the enemies as it does not perform well visually. This set up is
also apply to the two bosses in different script named `TaController`.

### Bullet Movement

The RigidBody 2D is also used in the different types of the player's skills,
including the bullets and shield, to perform the movement. In the script
`PlayerShooting`, the RigidBody is needed to
[calculate the angle between the direction towards the target (nearest enemy) and the x-axis](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/PlayerShooting.cs#L60),
and then rotate the bullet(Quaternion.Euler) to face that direction. In the
script `Bullet`, the RigidBody is
[used for the velocity and angular velocity](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/Bullet.cs#L28)
of the bullets, allowing the bullets to move toward the enemy. These are applied
to all the bullets that shoot toward the enemy, while the circle shield moves
with the player without delay. Moreover, the "merry-go-round" bullet will
[move around the player](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/MerryGoRound.cs#L33)
counterclockwise with a radius distance from the player's center, each
merry-bullet is able to move with the given speed and center point with the help
of the provided function, "transform.RotateAround". Our group member, Weo Shao,
has also made huge contribution in implementing the bullets' movement patten.
![image](https://hackmd.io/_uploads/BkNo1LiAa.png)

### Player Physics

In the script `PlayerCollision` and `PlayerStatsManager`, the Collider 2D
component is used in the player in order to perform the collisions with the
enemies and prefabs. The collision between the prefab "Gem" and "Code" is set in
`PlayerStatsManager`, where the prefab is destroyed once the collision occurs
and then calls the appropriate functions. In the `PlayerCollision` script, the
collisions with the "Enemy" and "HP bottle" prefabs adjusted the player's health
bar and some other features. These collisions are all determined based on the
tag of the game object that is currently colliding (OnCollisionEnter2D) and is
set to perform different functions based on the tag.
![image](https://hackmd.io/_uploads/SyKw1BiRp.png)

### Enemy Physics

All enemy prefabs contain the Box Collider 2D, excluding the second boss, this
prevents the enemies from overlapping each other and also allows them to perform
specific functionality when colliding with different game objects. The script,
`EnemyController`, performs the collision detection between the enemy itself and
other objects, including the player, the player's bullets, and the enemies' drop
item. The collisions are detected based on the tag of the game object. After the
enemy spawned, the enemy will
[turn off the collisions between all game objects with the tag "Gem"](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/EnemyController.cs#L29),
this prevents the enemy from pushing the gem while moving. The enemy will also
[ignore the collisions between the other drop items](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/EnemyController.cs#L69)
during playtime with the help of the given function, "OnCollisionEnter2D". This
is not in the start function because the item may not be in the older spawned
enemy's ignore list if the later spawned enemies drop the item. The second boss
use a poligon collider 2D as it is larger than the other enemies and a bigger
head than body. ![image](https://hackmd.io/_uploads/H1DheSoRp.png)
![image](https://hackmd.io/_uploads/rkdOm8sRp.png)

### Bullet Physics

The collisions for the player's skills(bullets and shield) are separated into
multiple files, including `Bullet`, `TaBullet`, `Shield`, `APbullet`, and
`Merry`. Overall, these skills all perform similarly, where they will detect
collisions by the function "OnTriggerEnter2D" or "OnCollisionEnter2D" and
determine the collisions by comparing the tags. After the player's skill
spawned, I have to make sure that the collisions of the object only occur with
the enemies and is able to ignore the enemy's drop item as well as destroy it
when colliding with the enemies or map edge.
![image](https://hackmd.io/_uploads/ByVHESs0a.png)

## Animation and Visuals - Lin Yiqiao

**List your assets, including their sources and licenses.**

-   At the very beginning, we have decided our game this about the course
    Gameplay programming itself, and we thought our enemy will be the assets
    from each Exercise we have done. Therefore, I started to create our enemy
    prefab. Below are some examples. I used the Captain animation as referance
    to build our prefabs animation. Here is some example that I used previous
    exercise assets to build some enemy moving and attacking animation.
    ![Enemymoving](https://hackmd.io/_uploads/Sk77bYiRa.gif)
    ![Enemyattack](https://hackmd.io/_uploads/rJxOxKoRa.gif)
-   When I build the animator of our prefab, we have a logic that when the enemy
    collide with our player, the enemy should play the attack animation, but
    seems like one boolean IsHit() condition for transition states is not enough
    because the enemy will only show the first frame of the full animation, so I
    decided to add another boolean IsHitCooldown() condition and add some code
    to control the boolean in script "EnemyController.cs" to make sure the enemy
    played the attack animation correctly.
-   Then I began to build another enemy, the Capsule and the pikimini. For the
    Capsule, Unity has this shape, I built it easily, but the problem comes with
    pikimini, we don't have its 2D asset. Therefore, I used an online pixel
    drawing tool to make the pikimini by myself. In the end we have three type
    of pikimini separated by their color. I didn't do the actual animation for
    these enemy because they have too simple shape.
    ![capsule](https://hackmd.io/_uploads/r1vVdYs0a.png)
    ![greenman](https://hackmd.io/_uploads/HyTVOtsAp.png)

-   Next comes to the player part. The player itself has two animation, running
    and idel. It is basically built by that drawing tool. I designed the main
    character bald head，He lost all his hair because he wrote too much code!
    ![playeridel](https://hackmd.io/_uploads/SyN9FKjAT.gif)
    ![playerrunning](https://hackmd.io/_uploads/SkaV9tj0T.gif)

-   Then it comes to the player related part. The player will have several
    abilities : fireball, iceball, MP bullet, AP bullet and Shield.
-   For the fireball and iceball, I got the free asset from
    [Unity Asset store](https://assetstore.unity.com/packages/2d/characters/2d-pixel-spaceship-two-small-ships-131545).
    I don't want the attack just shoting chartlet so I made the animation of
    those attack, simply iceball zooming and fireball rotation. In game, you
    might find that the iceball has the animation but the fireball doesn't,
    because we met a bug we cann't fix in a short time that if we apply the
    animation to the fireball. I think the problem is caused by the Z changing
    in the animation has a conflict with the automatic bullet capture mechanism.
    ![fireball](https://hackmd.io/_uploads/rydrXqo0T.gif)
    ![iceball](https://hackmd.io/_uploads/SJJ_XcoCp.gif)

-   For the shield, I tried to build the fancy middle-transparent 2D shield
    instead of the 3D shield in Exercise, but when I applied it as the material,
    the shield can't appear in game even though we back to Scene and figure out
    it does generated. In order to actually see the shield, We had to draw a
    circle of our own to use as a shield.
    ![Shield](https://hackmd.io/_uploads/r19nf9jR6.png)
    ![ShieldAlter](https://hackmd.io/_uploads/B1Dx7qi0a.png)

-   MP bullet and AP bullet are some final change we made, I don't have time to
    make it more fancy. ![MG bullet](https://hackmd.io/_uploads/HkG72toAT.png)
    ![AP bullet](https://hackmd.io/_uploads/HkAlpKiCT.png)

-   The finally prefab I build are Professor and TA boss and the attendance code
    prefab that drop by TA boss. We must credit our source provider --
    [Krystal Chau](https://github.com/oycheng/McDungeon/blob/master/ProjectDocument.md)
    Her art for attendance code and professor is very fit our main idea so we
    used their asset resource to build animation. Since we have different TA, I
    used again the online pixel drawing tool to change the visual of TA prefab
    so that the player can feel more immersive.
    ![professor](https://hackmd.io/_uploads/SkTKBKoRp.png)
    ![attendancecode](https://hackmd.io/_uploads/SJ4mItsAa.png)
    ![ta](https://hackmd.io/_uploads/SyfvLYiAa.png)

## Game Logic - Wei Shao

### Enemy Spawner - Factory Pattern

-   The
    [`EnemySpawner.cs`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/main/GPSurvivors/Assets/Scripts/EnemySpawner.cs)
    script is designed to dynamically generate enemies in our game.
-   Attached to a GameObject named 'Spawner', it requires references to various
    enemy prefabs and the player GameObject.
    ![image](https://hackmd.io/_uploads/HJ_Clwj0T.png)

    ![image](https://hackmd.io/_uploads/BkKufvo06.png)

-   The script includes several serialized fields, such as `spawnRate`, which
    determines the delay between each batch of enemies, and`spawnRadius`, which
    determines the range of generating position from the
    player.![image](https://hackmd.io/_uploads/rk1ifvsAp.png)

-   Based on the player's level, different amounts and types of enemies are
    generated. It also manages two special types of enemies: TA and Professor.
    [`SpawnEnemies()`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/EnemySpawner.cs#L92)
    [`SpawnTA()`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/EnemySpawner.cs#L65)
    [`SpawnProf()`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/EnemySpawner.cs#L92)
-   The spawn position is randomly generated and validated to ensure it is
    within bounds; invalid positions are recalculated until valid. There is a
    safe radius that prevents from spawning enemies on or too close to the
    player.
-   The script handles the game's victory conditions, specifically defeating the
    TA and Professor. ![image](https://hackmd.io/_uploads/Hyzhmvs0T.png)

### Helath Bar - UI and Script

-   The Health Bar UI and the
    [`Health.cs`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/main/GPSurvivors/Assets/Scripts/Health.cs)
    script are tasked with managing and visualizing a GameObject's HP value.
-   Handling health-related functionalities such as taking damage, healing,
    updating the visual representation of the health value (via the health bar
    UI), displaying scrolling text for damage and healing events, and managing
    death conditions for the attached GameObject. Shijie contributed by adding
    drops for the blue gem and HP bottle,
    ![image](https://hackmd.io/_uploads/r18fdPjAp.png)
    [`TakeDamage()`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/Health.cs#L23C17-L23C27)
    [`Heal()`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/Health.cs#L42)
    [`ShowScrollingText()`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/Health.cs#L111)
    [`Die()`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/Health.cs#L56)
-   Adjusted the Health Bar UI to accommodate different sizes/scales and prefab
    properties. ![image](https://hackmd.io/_uploads/SkJxkjqRa.png)
-   Maintained `CurrentHealth` and `MaxHelath` for the obkject.
    ![image](https://hackmd.io/_uploads/Hym-ks5AT.png)

### Enemy Controller - Controller Pattern (?)

-   In the
    [`EnemyController.cs`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/main/GPSurvivors/Assets/Scripts/EnemyController.cs)
    script, contributed to developing a simple AI for enemy movement. Enemies
    are programmed to dynamically move towards the player's position.
-   Maintained `Speed` value for moving speed of the object.
    ![image](https://hackmd.io/_uploads/B1HZFviCp.png)

### Player Controller - Controller Pattern

-   The
    [`PlayerController.cs`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/main/GPSurvivors/Assets/Scripts/PlayerController.cs)
    script facilitates player movement in response to keyboard inputs, with
    gameplay involving movement via the WASD keys or the arrow keys (Up, Left,
    Down, Right).
-   Additional code contributions were made by other team members.
-   Maintained `Speed` value for moving speed of the object.
    ![image](https://hackmd.io/_uploads/ryhwFwjAa.png)

### Player Collision

-   The
    [`PlayerCollision.cs`](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/main/GPSurvivors/Assets/Scripts/PlayerCollision.cs)
    script manages collisions between the player and other objects, such as
    enemies and HP bottles.
-   It enables player interaction with these objects through keyboard inputs,
    with specific reactions triggered by collisions, categorized by the object
    types (e.g., `Enemy` and `hpBottle`)
-   Maintained collision `Damage` for the object.
    ![image](https://hackmd.io/_uploads/HygKYvo0p.png)

### Position Lock Camera - Camera Controller

-   Leveraging previous assignments/exercises, the `PositionLockCamera` script
    ensures the camera is consistently locked to the player's position,
    maintaining a fixed perspective that follows the player's movement
    throughout the game. ![image](https://hackmd.io/_uploads/B1A3yiqC6.png)

### Level Up UI - User Interface

-   Assisted in dynamically setting the text and functionality of buttons within
    the Level Up UI.
-   Involved implementing upgrade options that react to user clicks, allowing
    for a responsive and interactive level-up experience for the player.
    ![image](https://hackmd.io/_uploads/H1lYxj9AT.png)
    [LevelUp()](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/e229467906f10f5358ab1e7d336109322291ba1b/GPSurvivors/Assets/Scripts/PlayerStatsManager.cs#L94)

# Sub-Roles

-   Audio: Wei Shao
-   Gameplay Testing: Hauser Zhou
-   Narrative Design: Dongxian Li
-   Press Kit and Trailer: Lin Yiqiao
-   Game Feel and Polish: Shijie Wei

## Audio - Wei Shao

Attributed to previous
[assignments/exercises](https://github.com/dr-jam/GameplayProgramming), and in
line with the theme of course ECS 179, all elements utilized in this project are
sourced from the class materials. The audio system is designed to enhance
gameplay, featuring main background music that plays at the start of the game
and sound effects triggered by actions such as shooting, spawning, collecting
items, and recharging the shield.

## Gameplay Testing

Because we barely got most of the game done in the a.m. of the day before we
showed it, we didn't have time for anyone else to test our game and get
feedback. Because we often encountered technical problems in implementing
features during the process, we were slow and didn't have enough time for other
players to test and get feedback. However, after we finished the game, we
organized a short demo of the game for each group member and modified the
parameters and balance with feedback. Of course we also had problems like the
camera's field of view being too small causing the player to not be able to make
more strategies because we didn't have other people's opinions to take into
account, and this kind of problem is usually something that the people who make
it would have overlooked or not been able to think of. When I was working as a
game tester, I basically playtested every feature that came out to detect bugs
and fix them, and there were so many of these over the course of our production
that I can't list them all. Overall I made limited work as a gameplay testing
role, only bug fixes and game balance adjustments.

## Narrative Design - Dongxian Li

The narrative desigh of this game was to pay our respects to the game "Vampire
Survivors", but the background is the class of ECS 179.

### Background Story

Imagine that the class of ECS 179 is ruled by enemies, students must coexist
with these enemies in order to survive. As night falls, the enemies emerge from
the dark corners of the classroom, seeking their next prey. But in this world,
there exists a group of warriors known as the "Survivors”, individuals who
possess the ability and courage to fight against the enemies.

### Game Introduction

"Gameplay Programming Survivors" is an action-adventure game where players take
on the role of a survivor, tasked with surviving the night and battling various
threats. Players will explore different areas of the classroom of ECS 179,
scavenge for resources, and complete missions. The game blends elements of
action combat, exploration, and role-playing, immersing players in a world
filled with danger and the unknown.

### Key Features

-   **Survival and Resource Management:** Players must manage resources such as
    health, finding blue gems to increase the level, blood bottles to recover
    the health bar, or even the participation codes in order to survive in the
    darkness.
-   **Diverse missions:** Complete various missions such as killing the little
    enemies to get blue gems or blood bottles to level up.
-   **Dynamic World:** Time passes in the city, with enemies becoming more and
    more active at night. Players must act accordingly.
-   **Confronting Enemies:** Players will face different types of enemies,
    including the little monsters which stand for our class assignments, small
    boss which stands for our TA Kyle, and big boss which stands for our
    professor Josh, requiring them to use weapons and skills effectively.
-   **Character Development:** Gain experience through completing missions and
    battles to improve skills and abilities, customizing our own survivor.

### Game Narrative

#### Act One: Twilight Awakening and Nightfall

The player awakens in an abandoned classroom, surrounded by darkness. A
mysterious old man informs the player that they are a "Survivor", a human with
the ability to fight against enemies. The old man hands the player a worn-out
weapon, telling them that only strength will allow survival in this dark city by
killing those little enemies. Night has fallen, and the enemies begin to emerge.
The player must cautiously avoid enemy patrols, seeking shelter and resources to
level up and increase their skills and abilities.

#### Act Two: Threat of Challenges

Through completing missions and gaining experience, the player finds out the
small boss in the classroom with unique weaknesses and behavior patterns. The
player must learn to use the environment and weapons to effectively confront the
challenges.

#### Act Three: Face Difficulties and Overcome

While solving the challenges in the last stage, the player encounters a more
difficult situation. The player decides to challenge it, facing various trials
and challenges. In the end, the player engages in a life-or-death battle with
the big boss, the outcome of which will determine the fate of the entire class.

#### Endings

Because of the warrior and his smart choices and brave actions, it finally leads
them to survive successfully. The darkness will pass anyways, and the warriors
will see the flush of dawn eventually.

### Conclusion

"Gameplay Programming Survivors" plunges players into a world of challenge and
adventure, exploring the dark space, battling enemy threats, and experiencing
the joys of survival and character development. This game blends elements of
action, adventure, and role-playing, immersing players in a mysterious and
dangerous story.

## Press Kit and Trailer - Lin Yiqiao

**Include links to your presskit materials and trailer.**

-   [Press kit](https://raw.githack.com/YoungKameSennin/GameplayProgrammingSurvivors/main/demo-presskit/build/product/index.html)
-   [Trailer](https://www.youtube.com/watch?v=xlWIoJllBno)

**Describe how you showcased your work. How did you choose what to show in the
trailer? Why did you choose your screenshots?**

-   When I built the press kit, I used professor suggested format, the
    doPressKit(). But I was struggled with how to build a web server that can
    download doPressKit(). Thankfully,
    [solarsailer build a simple presskit that I don't need to build web server](https://github.com/pixelnest/presskit.html).
-   In the presskit, I chose GP Survivors starting UI as our header. Other than
    some basic information, I add the background story in narritive design
    document as a introduction for ourgames. In the images selection, I mainly
    chose the begin, upgrade and end UI, this because I want to show our fancy
    UI design. I also chose some in game scene like TA boss fight and Professor
    boss fight. This might help the player know what they can expect to fight in
    this game.
-   In the trailer, I used a story telling method to edit our video. By some
    simple words and game scene to tell the player story. In the video, I tried
    to show the player what skill they will have when upgrade and show some boss
    fight. The back sound track, I used
    [Escape Velocity - Steven Beddall](https://artlist.io/royalty-free-music/artist/steven-beddall/1394)
    which I think it's very fit to the content in the video.
-   For the black screen with white pixel words scene, I actually use google doc
    with black page color and type white pixel words and recorded it to
    ccomplish that.

## Game Feel and Polish - Shijie Wei

**Document what you added to and how you tweaked your game to improve its game
feel.**

-   I added the feature that when the player's bullets hit the enemy, that enemy
    will
    [change its color](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/EnemyController.cs#L113)
    to red for half of a second and change its color back to its original color.
    This feature greatly improves the user's feeling of impact when attacking
    the enemies. The feature is also implemented on the player when the enemy
    lands the hits on the player, giving the user better visual feedback.
    ![image](https://hackmd.io/_uploads/H1WE_8jRT.png)

![image](https://hackmd.io/_uploads/S1q9dUsAT.png)

-   I also worked on some of the UI designs to improve the game feel. For
    example, the
    [timer](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/UIExperienceBar.cs#L31)
    gives the player an additional challenge, where the players can compare
    their clearance time with each other, and also encourages the players to
    improve their skills and efficiency to beat the clock, enhancing replay
    value.

-   I also added the UI for the
    [display of the player's current level](https://github.com/YoungKameSennin/GameplayProgrammingSurvivors/blob/55b80785a665f31d43554b8296085d9eb469d3b3/GPSurvivors/Assets/Scripts/UIExperienceBar.cs#L33),
    which provides a clear indication of their progress within the game,
    improving the sense of accomplishment and satisfaction of getting stronger.
    ![image](https://hackmd.io/_uploads/SkAW_wiR6.png)

-   I also did some visual designs, for example, the text art and the background
    at the start menu. I found an
    [online website tool](https://textcraft.net/style/snegos/pixel-art) that can
    transform words into different styles and apply it to the game, including
    the game title, level-up text, gameover text, and you win text. This better
    text art gives players a better sense of involvement in the game.
    ![image](https://hackmd.io/_uploads/S1lbEdiRT.png)
    ![image](https://hackmd.io/_uploads/BJ9C4OiAT.png)
    ![image](https://hackmd.io/_uploads/BJg8rdo0a.png)
    ![image](https://hackmd.io/_uploads/H1gurOsA6.png)

-   Lastly, I adjust the layer of the drop items, so that the enemies and
    bullets can overlap on top of the drop items. This improves the visual
    effect by showing the item is indeed dropped on the ground and the enemies
    are able to step over it. ![image](https://hackmd.io/_uploads/BydhwOoRT.png)
