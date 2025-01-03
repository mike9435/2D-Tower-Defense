using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{
   /*
    * For this game I would like to create a 2D tower defense. Just a super super basic and dumbed down game. 
    * Here are the MUST HAVES:
    * DONE -Enemies that move to the end of the path and decrease the health once they reach the end successfully
    * DONE -A tower placing mechanic
    * DONE -A tower attacking mechanic
    * 
    * NICE TO HAVES:
    * -A gold mechanic
    * -Different paths
    * -Different enemies
    * -Different towers
    * 
    * KNOWN BUGS:
    * Bullet can kill 2 enemies at once
    * instantiatedSlider for boss will not destroy after boss is dead
    * 
    * Day 1:
    * Added Enemies AI and GameManager Scripts
    * Enemies AI will move them to the left of the screen
    * GameManger set to delete Enemy and decrease health by 1 once they reach the end of the path. This is currently 
    * bugged as it is not working and when manually placed at -9 it occurs multiple times. Will need a bool to get it to only
    * occur once. To fix it not triggering, probably needs to be less than -9 instead of exactly -9
    * 
    * Day 2:
    * Fixed where the health was not triggering or triggering multiple times.
    * GameManager set to detect enemies that have spawned and put them into an array
    * GameManager currently spawns all 10 enemies at once. Will need to fix this by adding a delay or timer
    * 
    * Day 3:
    * Added Plots and Plot script
    * Added a button that appears over a plot when the mouse hovers over it
    * I attempted to make a menu for the towers but after a long time I could not figure it out so I think I will make it just create 1 tower.
    * I will also need to make the button stop showing up once it is pressed.
    * I also attempted to make a timer for the spawning using a while loop. I didnt get to test it as my Unity kept loading forever.
    * edit: Timer frezes Unity for some reason. probably a time loop somwhere.
    * 
    * Day 4:
    * Timer got frustrating so I decided to make it a coroutine and use WaitForSeconds(). This helped alot
    * Changed the button to make it say build and have a gold icon and cost. I cheated and stole someone elses asset but I may make my own down the road.
    * Now the button is gettin frustrating. I tried to get it to go away once you click it but I couldnt get the bool to communicate with the rest of
    * the script. I think this has something to do with it instantiating but im not sure. I think a solution could be to make a new plot once you
    * press the button so It just has an entirely new script.
    * 
    * Day 5:
    * Took more time tring to fix the button. Decided to just make a "Tower" prefab and delete the "plot" prefab and deleted the button with it. 
    * Next, I need to make the tower which is gonna involve it to have a range, aim at the enemies, fire at them, and then delete them once they collide.
    * 
    * Day 6: 
    * Made the button subtract 10 gold from the total gold when a tower is built
    * 
    * Day 7: 
    * Started on TowerAI but couldnt figure out how to work Physics2D.CircleCast. It may be to difficult so I should try something easier.
    * 
    * Day 8:
    * Fixed tower range by making all enemies in AllEnemies[] array
    * Added Bullet Prefab and BulletAI script
    * Added Fire() IEnumerator to TowerAI but couldnt get it working properly
    * 
    * Day 9:
    * Bullets now work properly! With the help of ChatGTP I got the tower to have a delay between shots
    * Enemies get destroyed when collided with bullet
    * Enemies add gold to total when destroyed
    * NEW BUG: bullet can kill 2 enemies at once
    * NEXT: Find a way to make the waves come in periodically, I think I may do it entirely manually where I just time out the waves where I want them.
    * 
    * Day 10:
    * Added timer but doesnt work
    * 
    * Day 11:
    * Fixed timer by using bools and setup round manually at a specific time
    * Added Wave UI to show waves
    * FIXED: Towers will now see if an enemy is already getting shot before shooting it
    * Made enemies faster
    * Made enemies give 1 gold instead of 2
    * Added boss enemy after wave 5 (was still messing with it but didnt get to test it last time. Also need to make the plots not collide)
    * 
    * Day 12:
    * Boss no longer collides with plots
    * Towers were only shooting the boss once. This is now fixed
    * NEW BUG: instantiatedSlider for boss will not destroy after boss is dead
    * NEXT: I want to try to add sound effects and maybe particles. EX: sound when building a tower, firing a bullet, killing an enemy. particles behind bullets, behind enemies.
    * 
    * Day 13: 
    * Added sound effects for the towers firing and the enemies dying
    * 
    * 
    * Game Jam Mostmortem:
    * Hello Week Sauce game jammers! After lurking in this discord for a while, I am here to show off my new game I have made!
    * 
    */

}
