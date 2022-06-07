===Multiple Cameras Unity Package===


---Setup---
1. Setting how many cameras to switch between
   - Place the CameraSwitchPrefab in your scene
   - Open the prefab up in the hierarchy and click on the CameraSystem
   - In the inspector change the number of cameras you would like

2. Set the camera views that will be switched between
   - Place as many cameras as you want in the place you want them
   - Create as many render textures as you need and assign each a camera
   - Create Materials and assign each of them to a raw texture (Change the material to be UI/Unlit/Detail)
   - Back on the CameraSystem assign each of the materials to the element slots in the inspector

---Activate---
   - Press F while the CameraSwitchPrefab is in the scene to view the camera screen
   - Use the left and right arrows to switch camera
   - Press F to hide the camera screen