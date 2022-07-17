## UnityML Jump & Run

This project is developed using Unity Framework implementing Reinforcement Learning algorithm PPO to train the ML-Agent to Jump & Run and earn Reward points by jumping over obstacles and collecting coins.

## Tools & Packages Version Download

Software							                         |                       					Release Version
----------------------------------------------------------------------------------------------------

Unity ML Agent 									               |                                 1.0.8

Unity Editor										               |                                 2020.3.36

Python Version									               |                                 3.8

Python ML-Agents								               |                                 0.16.1

Python TensorFlow                              |                                 2.2.0

----------------------------------------------------------------------------------------------------

## Game Demo

<img width="1280" alt="image" src="https://user-images.githubusercontent.com/31996588/179427371-9bff6ee5-dc9f-4ec4-84a4-b743fc2dba85.png">

## Levels of Game

There are 5 levels in the game

Level 1 :  The agent needs to jump over cars that are all of the same height. Moreover, coins are placed on ground level. Since the agent tries to earn the maximum   reward, it needs to jump at the right times to avoid cars but collect the coins on the ground.

Level 2 : The obstacle does not change but the coins are now at different heights so the agent needs to time more jumps.

Level 3 : The distance between obstacles gets shorter as the agent progresses.

Level 4 : Introduced a new obstacles, a wall, that has a different height than the cars. Also, the distance between the obstacles is minimized as the game progresses.

Level 5 : Both types of coins appear at the same time in different heights, so the agent has to prioritize which coin to collect for the maximum reward.

## Reward Systems

<img width="500" alt="image" src="https://user-images.githubusercontent.com/31996588/179427858-cce231e4-11bb-49c9-b01a-2d3c498df394.png">

The most important functions used in our reinforcement learning are:

• Heuristic(float[] actionsOut): 
This function gives a test environment to see if all features of the game is working before the training. If ML-agents is not being used, then this function acts as the intermediate. The user can give "spacebar" inputs to manually make the player jump.

• OnActionReceived(float[] vectorAction): 
The vectorAction is taken as a discrete value. If the action received is heuristic, i.e on the press of Spacebar OR if the system provides an action which is equal to 1, the agent/ player jumps up.

• OnCollisionEnter(Collision collidedObj): 
This function gives negative reward to the agent in certain conditions.
In this function the system has two options: 1. if the player is on the street, they can jump 2. if the player already collided with an obstacle, the Agent receives a negative reward of -1.0f.

• OnTriggerEnter(Collider collidedObj): This function gives positive rewards to the agent if triggered. This function is triggered in one of the 3 cases:

1. The agent jumped over an obstacle successfully. Reward: 0.1f
2. The agent has collected silver coins. Reward: 0.5f
3. The agent has collected gold coins Reward: 1f

## Evaluation

On training the model for each level, we got below results.

<img width="500" alt="image" src="https://user-images.githubusercontent.com/31996588/179428014-f0985432-f4ed-4f04-9c37-c062972a19ad.png">







