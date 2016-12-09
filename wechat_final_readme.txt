Readme

i) Team Members

	As team leader, I would like to point out that Michael as the team member has not done anything except the intial version of play testing questions after Alpha. All the game currently is done by the rest of team. In total, the team has spend over 40 man hours on the final version which Michael does not contribute any. All the information above is true and I have Google Drive, and Github as evidence.

	Nan Li, nli78@gatech.edu, nli78
	Rui Wang, rwang387@gatech.edu, rwang387
	Michael Azogu, mazogu3@gatech.edu, mazogu3
	Yuyang He, yuyang.he@gatech.edu, yhe95
	& Aoyi Li, ali327@gatech.edu, ali327

ii) Details

	1) The followings are completed according to Milestone4_16Fall.pdf:
		a) The game should start with an introduction menu scene. This menu scene should have a
		polished feel with intuitive interaction. At the minimum the menu scene should have the
		title of the game, your team name, a menu button to start the game and a menu button to
		show the credits.
		
		There are 4 buttons, "story", "start the game", "credits", and "quit".
		"Story" - It will show an introduction of the background story.
		"Start the game" - It will loaded scene 1, which currently only shows the envrionment of the game.
		"Credits" - It shows all team members.
		"Quit" - A confirm option will be shown. And user can choose to quit the game (in Unity editor and executable file).
		
		b) The background environment should be visually appealing and animated in some fashion.
		This doesn’t have to be overly complex just something more entertaining than a static
		color or static image.
		
		A video will be the background playing looply while user stays in the main menu.
		A movie texture is used here.
		A font called "horror" is used for game feel. But due to the feture of this font,
		it is not very clear when the font is small. So the keyboard control instruction is in Arial.
		When clicking 4 buttons, a water blue shader will be activated. Even though the background movie
		is still being played, the shader will blur the screen.
		
		c) The menu items should be aesthetically positioned and styled.
		
		All items are well-positioned and styled.
		
		d) Your menu system should be navigable with a controller or keyboard in addition to normal
		the mouse clicking.
		
		Mouse and keyboard will alwaysbe available for navigation (even in the game scene 1).
		The selected item by the keybard will be shown in white color.
		
		e) The credits for the game should be fully informative on all contributions.
		
		Nan Li - Normal citizens character with transfomation from dead citizens to infected people character.
		Rui Wang - Street environment, and infected people character.
		Michael Azogu - Infected people character.
		Yuyang He - All menus and the player character.
		Aoyi Li - Soilder character, and UFO elements with particle system.
		
		f) The credits for the game should be visually compelling in some way.
		
		It is very easy to see all credits since after clicking the start game button, 
		all characters will be shown in the scene even though they may not work. We have disabled
		all animations and scripts because they are not all finished yet. 	
		
		g) You will implement at least couple different visual or image effects to add polish to your game.
		These include lens flare, halos, bloom, motion blur, depth of field, color changes, edge
		detection, etc.
		
		This has been explained pretty clearly in other parts.
		
		h) You are responsible for researching the two techniques you deem appropriate for your game.
		Implement the effects and clearly document how they are used.
		
		<1> A movie texture is used (background loop movie in menu scene). 
		Firstly, Yuyang transfers the movie from .mp4 format into .ogv since Unity directly read that. 
		And then Yuyang uses a new plane, and changes its texture into the movie texture Yuyang created. 
		Yuyang did in this way because only Unity pro provides support movie texture. What Yuyang did is
		almost all script because APIs are the same in both versions.
		
		This can be found in the script folder - menu script folder. 
		And can be found in the hierarchy view where a disabled movie background object is shown.
		
		<2> A shader is used (when clicking the menu in menu scene).
		The shader provides a water blur effect. In this way, when user reads many texts, a relatively 
		static background will not distract the user. And after user goes back to the main menu, 
		the shader will be disabled again and movie can be shown clearly.
		
		This can be found in modles folder - shaders folder. Yuyang spent serveral hours to learn to write this.
		In the hierarchy view, a shader object has this water blur material.

		i) We also fixed many bugs as descripbed in the playtesting script.

		<1> We changed the animation of player attack, which even though may be not looked good, but is really to control.

		<2> We added the exit gate as descripbed.

		<3> We changed the AI patrol to make them more "random". But the efefct are not as good as we expect.

		<4> The transformation from a dead citizen to a zombie is more smoothly compared to the previous one. Also, the "walking-in-sky" zombie is fixed by changing the collider.

		All above is a must-do as described in the playtesting script.
		
	2) There is nothing uncompleted according to the pdf.
	
	3) There is nothing buggy according to the pdf.

iii) Detail any and all resources that were acquired outside of class and what it is being used for.

	1) All animations and characters, even though they are skin free, are selected and downloaded in Mixamo.
	But all script controls are made by the team.
	2) Font "horror" is found online: 1001fonts.com/youmuderer-bb-font.html
	3) The background movie "Zombie Chse Parkour POV" is found in Youtube: youtu.be/IQHIZoB1jw
	4) The background music "Scary horror music" is found in Youtube: youtu.be/YUWi9ytJhDc
	5) The street environment "Destroyed City Free" is found in Unity store: assetstore.unity3d.com/en/#!/content/6459
	
iv) Detail any special install instructions the grader will need to be aware of for building and running your code.

	1) Environment:
		Windows 10 Home Edition, 64 bit, 14393.351
		macOS 10.12.1
		Unity 5.4.0f3
		
	2) Key Map
	<i> In the menu
		Up / Down Arrow - Select last / next item (if reach down / top, will go to the top / down one)
		Enter - Confirm
		Esc - Back to last menu
		
	<ii> In the game
		Up / Down / Left / Right - Player control (with in-place turn)
		Space - Attack
		Esc - Pause, show pause menu
	
	3) If resolution is too small (e.g. 320 * 240), the scene may cannot show my name at top right of the screen. Recommend 1280 * 80 or higher.
	
v) Detail exact steps grader should take to demonstrate that your game meets assignment requirements.

	1) Click on the playable. After choosing a resolution, the game will start. 
	If start in the unity editor, running menu scene.
	
	2) Steps:
	
		a) Use a mouse to click every menu to check every functionality.
		
		b) Use up / down arrow key to select different item in the menu. 
		The selected one will be in white.
		NOTE: if there is only one available button, the button stays red.
		
		c) Use Enter / ESC to confirm / quit a selection.	

		d) In the game, use Up / Down / Left / Right buttons to control player, use space to attack. 

		e) If the soldier is coming, try to avoid being killed. After a certain amount of time, the exit gate will be opened (a particle system with bubbles). After running to the gate, the game will end.	

vi) Scene "menu" should to be opened first in order to show the game menu.