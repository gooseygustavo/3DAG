# Skybox Sampler - 9 free skies (Godot 4 + Unity)

Nine complete, seamless skyboxes, free to use in commercial and non-commercial projects (see each
folder's LICENSE.txt). Three come from each of the three paid sky packs by The_KnightShift:

- SpaceSkyboxes/  (Teal & Magenta Nebula, Ringed Gas Giant, Supernova Remnant)
  from Space Skyboxes: 20 Stylized Skies - https://the-knightshift.itch.io/space-skyboxes
- StylizedSkyboxes/  (Golden Hour, Thunderstorm, Moonlit Night)
  from Stylized Sky Skyboxes: 16 Day, Sunset, Night and Storm Skies - https://the-knightshift.itch.io/stylized-skyboxes
- AlienWorldsSkyboxes/  (Ringed Giant over Ocean, Volcanic Ash World, Tidally-Locked Terminator)
  from Alien Worlds Skyboxes: 16 Exoplanet Skies - https://the-knightshift.itch.io/alien-skyboxes

All three packs (52 skies) are also sold together: https://itch.io/s/203326/skybox-bundle-52-skies-for-godot-4-and-unity
The skies are made with SkyGen, a Godot 4 sky generator you can use to make your own: https://the-knightshift.itch.io/skygen

## Try a sky in your own Godot 4 scene (2 minutes)

1. Copy one folder's godot/addons/<pack>/ into your project's addons/ folder.
2. Select your WorldEnvironment node (or add one) and drag environments/<sky>.tres onto its Environment.
3. Run the scene. The sky also lights the scene (ambient light and reflections come from the sky).

Or open godot/ as a project and run demo.tscn to flip through that folder's skies.

## See all 9 skies light real geometry (AllSkiesDemo/)

Open AllSkiesDemo/ in Godot 4.5 or newer (Import, select project.godot) and press F5. A test scene (floor, a
mirror ball, a rough ball, blocks) is lit by each sky in turn; Left/Right switches skies. Its addon,
AllSkiesDemo/addons/skybox_sampler/, holds all 9 skies in one folder (JPG panoramas, materials, Environments)
and can be copied into your own project as it is. It is the same addon as the Godot Asset Store version.

## Unity

cubemaps_unity/<sky>/ holds Front, Back, Left, Right, Up, Down PNGs for a Skybox/6 Sided material;
unity_panoramas/ holds panoramas laid out for Skybox/Panoramic. UNITY.md in each folder has the steps.

## What is in each folder

panoramas_2048/ (2048 x 1024 equirectangular PNG), cubemaps_godot/<sky>/ (px, nx, py, ny, pz, nz, 512 px),
cubemaps_unity/<sky>/ (512 px), unity_panoramas/, and godot/ (a Godot 4 project with the addon: a sky
material and an Environment per sky). The paid packs have every sky at 4096 x 2048 with 1024 px cube faces.

Made with AI assistance: the skies are painted by procedural code written with AI help, then checked by
eye and by numeric seam checks. No AI image generator was used.
