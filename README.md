Created using Unity 2018.1

# About
Create randomly generated dungeons from premade rooms by using only 3 components.

![output](https://user-images.githubusercontent.com/9346563/42738521-cab032ec-8839-11e8-9426-ffda926e4e47.gif)

# How to install
Copy the `Assets/Scripts` folder to somewhere inside your projects Assets folder. You may rename the folder to whatever you'd like. The prefabs and scenes folder are optional

# How to use
Create a game object and add a `MapGenerator` component to it. Fill out the fields to your needs. 

Next you need to create the rooms this generator can use. Create a game object that will be used as the room. Add a `Room` component and set the `Bounds` value which is used for the collision testing when trying to place a room. When editing the `Bounds` you should be able to see a Red rectangle based off it's values in the Scene View. Make sure the `Bounds` covers the whole room area.

Next your room needs X children with a `RoomSpawn` component. Move these children around to where the next room should spawn. The spawning works by aligning/connection the `RoomSpawn` spawns.

Once you have all your rooms created add them to the `MapGenerator` component. If you want a room to have a higher chance to appear you can add it multiple times.

To start the generation you just need to call the `Generate()` or `Generate(int seed)` function from the `MapGenerator` component. 

Script API
