# 2D Camera Zones
Add these components to your game to make camera transitions between different areas. This package uses Cinemachine.

## Contents
This component is made up of the following states:

- "CameraRegister"
- "CameraSwitcher"
- "CameraTriggerVolume"

### CameraRegister
This component is attached to a Cinemachine Virtual Camera and allows it to register and unregister itself by accessing the CameraSwitcher script when it is enabled and disabled, respectively.

### CameraSwitcher
This component is a static class that handles the camera transitions. It uses a static bool to determine which camera is active, and updates to whatever camera is triggered, setting its priority to 10 and the other cameras to 0 to allow the switch to occur.

### CameraTriggerVolume
This component is attached to the camera zone and uses a trigger collider to detect when the player enters the zone, which will then access the CameraSwitcher script to switch to that zone's camera.
