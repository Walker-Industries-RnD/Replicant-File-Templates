# Replicant File Writer - File Structure and Guidelines

## File/Folder Referencing
When referencing a file or folder, use `.` to specify the file's location, similar to GitHub.

> [!NOTE]  
> I need to make the mod file template, i'll return at the end and do that

---

## Folder Structure

### Folder Base
The base folder name should include the AI name and a UUID for unique identification.  
Example:
- 📁(AIName+UUID)  
  - 📄ExampleAI.Arhuasys  
  - 📄BGInfo.bg2d  
  - 📄BGInfo.bg3d  

---

### History Folder
The `History` folder stores session-related data and saved media.

#### Subfolders:
- 📁Sessions  
  - 📁Single Sessions  
    - 📄GettingOverEvents.session  
  - 📁Multi Sessions  
    - 📄DevilMayCryMeetup.session  
  - 📁Application Sessions  
    - 📄TitanFall2Gameplay.session  

- 📁Saved Media  
  - 📁Single Sessions  
    - 📄DMC4.png  
  - 📁Multi Sessions  
    - 📄TheGroup.mp4  
  - 📁Application Sessions  
    - 📄Quips.mp4  

---

### Environments
The `Environments` folder organizes 2D and 3D background files.

#### Subfolders:
1. 📁2D Backgrounds  
   - 📁General  
     - 📁ExampleEnvironment  
       - 📁MainBG  
         - 📄DMCStreet.img  
         - 📄DMCLogo.gif  
       - 📁GeneralAssets  
         - 📄media.gif  
   - 📁Encrypted  
     - 📁ExampleEnvironment  
       - 📁MainBG  
         - 📄media.img  
         - 📄media.gif  
       - 📁GeneralAssets  
         - 📄media.gif  

2. 📁3D Backgrounds  
   - 📁General  
     - 📁ExampleEnvironment  
       - 📁Furniture  
         - 📄couch3x1.glb  
         - 📄table 2x1.glb  
       - 📁Base Environments  
         - 📄Room.glb  
       - 📁Props  
         - 📄desktop.glb  
       - 📁Anims  
         - 📄computeron.anim  
         - 📄typing.anim *(Consider adding procedural animation options)*  
   - 📁Encrypted  

---

### Simulacrum Base
A folder dedicated to the simulacrum, named accordingly.

#### Considerations:
- This might be restricted to 3D environments only.  
- Features may include automation similar to the AI City research paper.

---

*This folder structure provides a clear organization for sessions, saved media, environments, and simulacra, ensuring ease of use and scalability.* 
