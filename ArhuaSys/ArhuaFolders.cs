using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//We use https://github.com/ForeverZer0/SharpNBT/wiki/Building-NBT-Structures#tagbuilder, specifically contexts
//For 2D we use https://github.com/Inochi2D/inochi2d
//For 3D we use .vrm files, although anims are saved as a separate thing
//For voices use https://github.com/rhasspy/piper

//We save the favorites as a .json file, also we encrypt EVERYTHING through kybers

//Background2D is just images (gif or )
//Background3D holds data on the room and item placement within

//When handling 2D animations, it might be good to make it so there is a reference to camera and avatar placement

namespace Replicant.FileWriter
{
    public static class Templates
    {

        public void WriteReplicantFile()
        {

            var builder = new TagBuilder("ARHUAFILE");

            //Spells REPLICANTCORE and has a filetype ID, AKA our magic number

            byte[] MagicNumberHex = { 0x52, 0x45, 0x50, 0x4C, 0x49, 0x43, 0x41e, 0x4E, 0x54, 0x43, 0x4F, 0x52, 0x45, 0x01 };

            builder.AddByteArray("Magic_Number", MagicNumberHex);


            // Header - Version, Size, Author

            using (builder.NewCompound("Header"))
            {
                using (builder.NewCompound("Author"))
                {
                    builder.AddString("Name", "Default");
                    builder.AddString("Link", "Default");
                    builder.AddByteArray("Author_Image", "Default"); //1024x1024
                }

                builder.AddFloat("Version", 1.0);
                builder.AddLong("Filesize", 0); //Is this really needed?

                using (builder.NewList(TagType.Compound, "Version History"))
                {
                    builder.AddString("Version_Name", "Default");
                    builder.AddString("Details", "Default");
                    builder.AddString("Author", "Default");
                }



            }

            builder.AddString("AI_Tree", "Default"); //Is this part of a specific pack?


            //General AI Context
            builder.AddString("AI_Name", "Default");
            builder.AddString("Tagline", "Default");
            builder.AddString("Bio", "Default");
            builder.AddByteArray("Main_Image", "Default"); //
            builder.AddByteArray("Mini_Image", "Default"); //

            //AIs
            builder.AddString("General_Context", "Default");
            builder.AddString("Greeting_Message", "Default");

            using (builder.NewCompound("Color_Theme")) //Hexes
            {
                builder.AddString("Primary_Color", "Default");
                builder.AddString("Secondary_Color", "Default");
                builder.AddByteArray("Tertiary_Color", "Default"); /
    
          }

            //These are all conditional, with folders supposing to be in certain areas/

            //All 2D Assets are handled based on an Inochi 2D renderer, each file should be a .inp file 
            //Mouth and face anims start off with blendshapes for a few emotions and AEIOU, everything is packed in the inf already and these are descriptors

            using (builder.NewCompound("Avatars")
     
       {
                using (builder.NewCompound("2D"))
                {
                    //When handling this, we want to have avatars in the format of .inf file name, clothing, props and animations
                    //Let's group each avatar into it's own thing

                    using (builder.NewList(TagType.Compound, "Avatar"))
                    {
                        //Let's set the avatar basics
                        builder.AddString("Avatar_Name", "Default");
                        builder.AddString("Avatar_Description", "Default");
                        builder.AddString("Avatar_Path", "Default"); //The inf file
                        builder.AddByteArray("Avatar_Logo", "Default");
                    }

                    //Now about the different clothes for the avatar; let's start with clothes items
                    //For anything you want to change, use (clothes), for more detail you can also do (clothes(category))
                    //Categories are ... (add later)

                    using (builder.NewList(TagType.Compound, "Clothing_Items"))
                    {
                        builder.AddString("Clothing_Item_Name", "Default");
                        builder.AddString("Clothing_Item_Description", "Default");
                        builder.AddString("Clothing_Item_Category", "Default");
                        builder.AddBool("Clothing_Item_ID");
                        builder.AddString("Conditional_Formatting", "Default") //Won't be supported juuust yet, basically says what can and can't go

             }

                    using (builder.NewList(TagType.Compound, "Clothing_Presets"))
                    {
                        builder.AddString("Clothing_Preset_Name", "Default");
                        builder.AddString("Clothing_Preset_Description", "Default");
                        builder.AddBool("Clothing_Preset_ID"); //A list of 
                        builder.AddString("Conditional_Formatting", "Default")
       
             }


                }

                using (builder.AddString("Default_Animation", "Default"))

                using (builder.NewList(TagType.Compound, "Hotkeys"))
                {
                    builder.AddString("Animation_Name", "Default");
                    builder.AddString("Animation_Description", "Default");
                    builder.AddBool("Animation_ID"); //Built in
                    builder.AddString("Conditional_Formatting", "Default")
     
           }



                using (builderNewCompound("3D"))
                {


                    using (builder.NewList(TagType.Compound, "Avatar"))
                    {
                        //Let's set the avatar basics
                        builder.AddString("Avatar_Name", "Default");
                        builder.AddString("Avatar_Description", "Default");
                        builder.AddString("Avatar_Path", "Default"); //The inf file
                        builder.AddByteArray("Avatar_Logo", "Default")
         
           }

                    //Now about the different clothes for the avatar; let's start with clothes items
                    //For anything you want to change, use (clothes), for more detail you can also do (clothes(category))
                    //Categories are ... (add later)

                    using (builder.NewList(TagType.Compound, "Clothing_Items"))
                    {
                        builder.AddString("Clothing_Item_Name", "Default");
                        builder.AddString("Clothing_Item_Description", "Default");
                        builder.AddString("Clothing_Item_Category", "Default");
                        builder.AddBool("Clothing_Item_ID");
                        builder.AddString("Conditional_Formatting", "Default") //Won't be supported juuust yet, basically says what can and can't go

             }

                    using (builder.NewList(TagType.Compound, "Clothing_Presets"))
                    {
                        builder.AddString("Clothing_Preset_Name", "Default");
                        builder.AddString("Clothing_Preset_Description", "Default");
                        builder.AddBool("Clothing_Preset_ID"); //A list of 
                        builder.AddString("Conditional_Formatting", "Default")
       
             }


                }

                using (builder.AddString("Default_Animation", "Default")) ;

                using (builder.NewList(TagType.Compound, "Hotkeys"))
                {
                    builder.AddString("Animation_Name", "Default");
                    builder.AddString("Animation_Description", "Default");
                    builder.AddBool("Animation_ID"); //.anim files stored elsewhere
                    builder.AddString("Conditional_Formatting", "Default")
     
           }
            }


            using (builder.NewList(TagType.Compound, "Voice"))
            {
                //Let's set the avatar basics
                builder.AddString("Voice_File", "Default"); //The .onnx file
                builder.AddString("Voice_Config", "Default"); //License
                builder.AddString("Voice_Description", "Default"); //The details on this voice, should usually be one word like "Anger"
                builder.AddByteArray("Voice_Logo", "Default");
            }

        }

        public void WriteSimulacrumFile()
        {

            var builder = new TagBuilder("SIMULACRUMFILE");

            //Spells REPLICANTCORE and has a filetype ID, AKA our magic number

            byte[] MagicNumberHex = { 0x52, 0x45, 0x50, 0x4C, 0x49, 0x43, 0x41e, 0x4E, 0x54, 0x43, 0x4F, 0x52, 0x45, 0x02 };

            builder.AddByteArray("Magic_Number", MagicNumberHex);


            // Header - Version, Size, Author

            using (builder.NewCompound("Header"))
            {
                using (builder.NewCompound("Author"))
                {
                    builder.AddString("Name", "Default");
                    builder.AddString("Link", "Default");
                    builder.AddByteArray("Author_Image", "Default"); //1024x1024
                }

                builder.AddFloat("Version", 1.0);
                builder.AddLong("Filesize", 0); //Is this really needed?

                using (builder.NewList(TagType.Compound, "Version History"))
                {
                    builder.AddString("Version_Name", "Default");
                    builder.AddString("Details", "Default");
                    builder.AddString("Author", "Default");
                }



            }

            builder.AddString("AI_Tree", "Default"); //Is this part of a specific pack?

            using (builder.NewCompound("Color_Theme")) //Hexes
            {
                builder.AddString("Primary_Color", "Default");
                builder.AddString("Secondary_Color", "Default");
                builder.AddByteArray("Tertiary_Color", "Default"); /
    
          }

            //General AI Context
            builder.AddString("Simulacrum_Name", "Default");
            builder.AddString("Tagline_Short", "Default");
            builder.AddString("Bio", "Default");
            builder.AddString("General_Context", "Default");
            builder.AddString("Greeting_Message", "Default");

            builder.AddByteArray("Main_Image", "Default"); //
            builder.AddByteArray("Mini_Image", "Default"); //

            builder.AddString("CharactersList", "Default"); //The client generated UUID for each AI

        }

        public void WriteSessionFile()
        {


            var builder = new TagBuilder("SIMULACRUMFILE");

            //Spells REPLICANTCORE and has a filetype ID, AKA our magic number

            byte[] MagicNumberHex = { 0x52, 0x45, 0x50, 0x4C, 0x49, 0x43, 0x41e, 0x4E, 0x54, 0x43, 0x4F, 0x52, 0x45, 0x03 };

            builder.AddByteArray("Magic_Number", MagicNumberHex);

            using (builder.NewCompound("Header"))
            {
                using (builder.NewCompound("Author"))
                {
                    builder.AddString("Name", "Default");
                    builder.AddString("Link", "Default");
                    builder.AddByteArray("Author_Image", "Default"); //1024x1024
                }

                builder.AddFloat("Version", 1.0);
                builder.AddLong("Filesize", 0); //Is this really needed?


                using (builder.NewList(TagType.Compound, "Version History"))
                {
                    builder.AddString("Version_Name", "Default");
                    builder.AddString("Details", "Default");
                    builder.AddString("Author", "Default");
                }



            }

            builder.AddString("Session_Name", "Default");
            builder.AddString("Session_ID", "Default");

            builder.AddString("Session_Data", "Default"); //Data tree turned into binary

            //Each message should contain 
            //AI UUID
            //Message Context
            //Time, Message Tree Checksum
            //Binary file containing either references to media or the media itself
            //Reaction IDs like :happy_guy: by AI_Name, AI_UUID, Owner (For MP session)



        }

        public void WriteModsFile() //Practically this either is a tool or fineshot data; it can be both at once
                                    //If a DB is referenced, we should have a name for it; client side we should handle unlaoding and connecting the DB
        {
            var builder = new TagBuilder("Mod");

            byte[] MagicNumberHex = { 0x52, 0x45, 0x50, 0x4C, 0x49, 0x43, 0x41e, 0x4E, 0x54, 0x43, 0x4F, 0x52, 0x45, 0x05 };

            using (builder.NewCompound("Header"))
            {
                using (builder.NewCompound("Author"))
                {
                    builder.AddString("Name", "Default");
                    builder.AddString("Link", "Default");
                    builder.AddByteArray("Author_Image", "Default"); //1024x1024
                }

                builder.AddFloat("Version", 1.0);
                builder.AddLong("Filesize", 0); //Is this really needed?


                using (builder.NewList(TagType.Compound, "Version History"))
                {
                    builder.AddString("Version_Name", "Default");
                    builder.AddString("Details", "Default");
                    builder.AddString("Author", "Default");
                }



            }

        }


        public void WriteBackground2D() //Separate 2D bg
        {
            var builder = new TagBuilder("Background2D");

            //Spells REPLICANTCORE and has a filetype ID, AKA our magic number

            byte[] MagicNumberHex = { 0x52, 0x45, 0x50, 0x4C, 0x49, 0x43, 0x41e, 0x4E, 0x54, 0x43, 0x4F, 0x52, 0x45, 0x06 };

            builder.AddByteArray("Magic_Number", MagicNumberHex);

            using (builder.NewCompound("Header"))
            {
                using (builder.NewCompound("Author"))
                {
                    builder.AddString("Name", "Default");
                    builder.AddString("Link", "Default");
                    builder.AddByteArray("Author_Image", "Default"); //1024x1024
                }

                builder.AddFloat("Version", 1.0);
                builder.AddLong("Filesize", 0); //Is this really needed?

                using (builder.NewList(TagType.Compound, "Version History"))
                {
                    builder.AddString("Version_Name", "Default");
                    builder.AddString("Details", "Default");
                    builder.AddString("Author", "Default");
                }
            }

            using (builder.NewList(TagType.Compound, "Backgrounds"))
            {
                builder.AddString("Background_Name", "Default");
                builder.AddString("Background_ID", "Default");
                builder.AddString("Background_Description", "Default");
                builder.AddByteArray("Background_Logo", "Default");

                using (builder.NewList(TagType.Compound, "Backgrounds")) //Main BGs
                {
                    builder.AddString("Image_Name", "Default");
                    builder.AddString("Image_Link", "Default");
                }

                using (builder.NewList(TagType.Compound, "Backgrounds")) //Additive BGs (THings that aren't the main BG but add to the scene)
                {
                    builder.AddString("Image_Name", "Default");
                    builder.AddString("Image_Link", "Default");
                }

                using (builder.NewList(TagType.Compound, "Scenes")) //BGs and non BG assets mixed
                {
                    builder.AddString("Scene_Name", "Default");
                    builder.AddString("Scene_Description", "Default");
                    builder.AddString("Scene_Conditionals", "Default"); //In the format of (image_id, layer)@(image_id, layer)
                                                                        //This will play GIFs and transparent images
                }



            }


        }

        public void WriteBackground3D() //Separate 2D bg
        {
            //Default layout
            //Saved layout
            //animations
            //Toggable items
            //The glb file


            var builder = newTagBuilder("Background3D")
  
        //Spells REPLICANTCORE and has a filetype ID, AKA our magic number

        byte[] MagicNumberHex = { 0x52, 0x45, 0x50, 0x4C, 0x49, 0x43, 0x41e, 0x4E, 0x54, 0x43, 0x4F, 0x52, 0x45, 0x07 };

            using (builder.NewCompound("Header"))
            {
                using (builder.NewCompound("Author"))
                {
                    builder.AddString("Name", "Default");
                    builder.AddString("Link", "Default");
                    builder.AddByteArray("Author_Image", "Default"); //1024x1024
                }

                builder.AddFloat("Version", 1.0);
                builder.AddLong("Filesize", 0); //Is this really needed?


                using (builder.NewList(TagType.Compound, "Version History"))
                {
                    builder.AddString("Version_Name", "Default");
                    builder.AddString("Details", "Default");
                    builder.AddString("Author", "Default");
                }



            }

            builder.AddByteArray("Magic_Number", MagicNumberHex);

            //We save the environment as .glb, the 3D space of everything and items which can be added to the scene
            // |__| .-------.    Let's say this is our computer. How do we reference it in 3D space? First we will set the
            // |=.| |.-----.|    limitations of the environment as a grid (following the Project Replicant Example). Then, we
            // |--| || KCK ||    will give the object preset type (More coming later) and link to the .anim file for the
            // |  | |'-----'|    furniture. Then, we could create presets with those pieces and animate how non main furniture
            // |__|~')_____('    items are animated on the scene


            using (builder.NewList(TagType.Compound, "Envrionments"))
            {

                builder.AddString("AI_Tree", "Default"); //Is this for all AIs or only a specific subset? 

                builder.AddString("Environment_Name", "Default");
                builder.AddString("Environment_ID", "Default");
                builder.AddString("Environment_Description", "Default");
                builder.AddByteArray("Environment_Logo", "Default");

                using (builder.NewList(TagType.Compound, "Base_Environment")) //Main BGs
                {
                    builder.AddString("Base_Name", "Default");
                    builder.AddString("Base_Link", "Default");
                }

                using (builder.NewList(TagType.Compound, "Furniture")) //Additive BGs (THings that aren't the main BG but add to the scene)
                {
                    builder.AddString("Model_Name", "Default");
                    builder.AddString("Model_Link", "Default");
                    builder.AddString("Constraints", "Default"); //Length width height
                }
            }

            using (builder.NewList(TagType.Compound, "Anims"))
            {
                using (builder.NewList(TagType.Compound, "Anims")) //BGs and non BG assets mixed
                {
                    builder.AddString("Anim_Name", "Default");
                    builder.AddString("Anim_Description", "Default");
                    builder.AddString("Anim_Link", "Default"); //Link to .anim (should stem from scene base, not humanoid only for item itneraction)
                    builder.AddString("Anim_Type", "Default"); //Half body (upper/lower), fullbody, extra 
                    builder.AddString("Anim_Conditional", "Default"); //Requires certian scene, items, objects?
                    builder.AddString("Anim_Target", "Default"); //A list of who the anim is made for (Dante(UUID), Aoi(UUID, etc.)), ALL allows everyone in a pack to use
                }
            }




        }

    }


}
