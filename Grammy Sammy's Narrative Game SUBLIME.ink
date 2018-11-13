VAR chalk = false
VAR wallet = 25
VAR chalk_cost = 5

Late 1960s, Massachusetts.

Your mom is standing on the porch. -> Intro_Part_1

=== Intro_Part_1
+ [Talk to Mom]
-> Mom1

=== Mom1
Mom! Look! God sent me a baby!
...Excuse me?
Her name is Kimmy!
-> Kimmy1

= Kimmy1
+ [It seems that Kimmy has something to say.]
...
(Kimmy remains silent.)
-> Nope

= Nope
* {X} [...] -> Y
* {not X} [...] -> X

= X
That… No, Dana. God did not send you a baby.

What do you mean…? You said God sends people babies sometimes! You told me that.

Well… nevermind what I said. It doesn’t apply to you. God isn’t about to send you a baby anytime soon, trust me.

What! Why? I wished for a baby, and he granted my wish. Isn’t it obvious?

Where did you find this little girl? Honey, where’s your house?
-> Kimmy1

= Y
Kimmy, can you tell me where your parents are?

I can go home later if I want…

Well maybe God didn’t send her, but she came out of nowhere! Kimmy, you just… appeared, right? Where did you come from?

Ferry Street... I untied myself from the porch so I could go for a walk…

+[How strange] -> Odd

= Odd
It’s ok dear, let’s go to your house Kimmy… you said it’s on Ferry Street? Your parents are probably worried.

+[Head to Kimmy's house] -> Intro_Part_2

=== Intro_Part_2

Dana: I'm sorry... I thought God sent me a baby and I got so excited...

Kimmy Mom: Oh, don't worry. Thank you for finding Kimmy and walking her home. What's your name, dear? 

Dana: I'm Dana...

Kimmy Mom: I don't know many kids as responsible as you, walking Kimmy all the way home. I hope you two can be friends. I know Kimmy could learn a lot from you. 

Kimmy: My... friend? 

Dana: Yes! I’d love to be friends, Kimmy. Can I come by and play with you tomorrow?

Kimmy Mom: I've been looking for a babysitter, actually. Her grandma was helping with that before, but she... well, she can't anymore. Kimmy's normally alright in her harness on the porch, but she's getting a little old for that... If you'd like to play with Kimmy tomorrow, I'd be happy to pay you a quarter to keep an eye on her.
Dana: Wow! Yes, please! I'd love to! 
Kimmy Mom: My work schedule is a little... hectic. It'd be great to have you by in the morning. 
Dana: I'll be here first thing! Wow, I didn't expect to land a job today. Thanks so much! 
Mom: Well, that all sounds good to me. A summer job will be a nice way to keep busy. Now then, let's leave this nice family to their dinner.
Dana: Ok. Bye bye, Kimmy, and Mrs...? 
Kimmy Mom: Mrs. Munro. Again, thank you for giving Kimmy a hand. It was nice meeting you, Mrs. Navaroo. 
Mom: Likewise. 
Kimmy: Bye bye. 

+ [Day 1] -> Day1_Intro

-> Day1_Intro

=== Day1_Intro 
Dana:			Mornin’ Kimmy! I’m here to babysit, like I promised! Is your mom around?
Kimmy:			My mommy’s not inside. She left already.
Dana:			Oh, ok… Um, well… Is there anything you’d like to do today, Kimmy?
Kimmy:			No… I don’t know.
Dana:			That’s ok, do you have a friend you’d like to visit?
Kimmy:			No...
Dana:			Should we watch TV or something in your house?
Kimmy:			We don’t have a TV. My dad is in there too, so we should go play somewhere else. He’s busy.
Dana:			Ok then! Want to walk around and play some games with the other kids?
Kimmy:			Other kids…?
Dana:			You know, the neighborhood kids. Like Donna. Isn’t she your age? You’re both going to be in Kindergarten, right?
Kimmy:			Oh, yeah… I don’t think Donna is my friend though, so she probably wouldn’t want to play...
Dana:			Well, let’s go become her friend! There's lots of other kids around, too. Like Anthony. I know him from school.
Dana:			Come on, let’s go!
Kimmy:			...!

// + [Store] -> Store.Talk_to_Dean
// + [Kimmy House] -> Kimmy_House

-> Map

=== Map
+ [Go to the store] -> Store
+ [Go to the Playground] -> Playground
+ [Downtown] -> Downtown

=== Kimmy_House
// + [Kimmy's Home] -> Kimmy_Home
+ [Store] -> Store.Talk_to_Dean

=== Store
= Talk_to_Dean
Dean:			Hey, Kid.
Dana:			Hi, Dean. This is Kimmy. I’m babysitting her now.
Dean:			Well lookit that, aren’t you all grown up. You gettin’ paid?
Kimmy:			My mom pays Dana a quarter a day.
Dana:			That’s right! I’m here to buy some things… I mean, I haven’t gotten paid yet. This is my first day. But I have some money saved up!
Dean:			Hah, I wish I had that kinda discipline. I blew my budget on fabric last week.
Dana:			I need to save up money. For college, you know! My mom would get so mad if I didn’t plan ahead.
Dean:			Hah! Your mom’s got the right idea. I wish I’d saved up for college.
Dana:			So what did you spend all your money on? Your sewing classes?
Dean:			Nah, that’s over. I’m workin’ on some Halloween costumes for my cousins… and some new pants for myself. You know, gotta apply those skills somehow.
Kimmy:			I didn’t know people made clothes!
Dean:			They do, Kimmy, they do. I make sweaters, dresses, hats--you name it.
Dana:			You should sell your clothes at Jordan Marsh! That’s where I always find the nicest clothes.
Dean:			Hah! That’s a long ways off for me. But maybe someday… anyways, what can I get for ya?
-> Purchase 

= Exit_Shop
Dana:			Thanks, Dean!
Kimmy:			Thank you Mr. Dean!
Dean:			Bye bye girls. Have fun.

-> Map

= Purchase
You have {wallet} cents. 
What would you like to buy? 
{chalk : You have chalk.}

* [chalk - {chalk_cost}]
{ chalk_cost < wallet:
	~ wallet = wallet - chalk_cost
	~ chalk = true
	-> Bought
	-else: 
	-> NotBought
}
+ [Exit shop] -> Store.Exit_Shop

= Bought
You've acquired chalk!
+ [keep shopping] -> Purchase

= NotBought
You don't have enough money! :( 
+ [keep shopping] -> Purchase


=== Playground

+ [Linda] -> Linda 
+ [Janey] 
+ [Blythe]
+ [Open Map] -> Map

=== Linda

Kimmy:			Hi Linda... I haven’t seen you in a while.
Linda:			I went to visit my auntie right when school ended.
Dana:			Hi, Linda. Do you know Kimmy?
Linda:			We’re neighbors.
Kimmy:			Did you go far away?
Linda:			Auntie’s in Boston.
Kimmy:			That sounds far...
Dana:			It’s not so far. You can even ride your bike there. Sometimes my sisters and I go. We like to go explore all the clothes shops. Like Filene's.
Linda:			I don’t really go shopping, unless it’s for stuffed animals.
Kimmy:			Dana is babysitting me, so she can go shopping with the quarters my mom gives her!
Linda:			Oh, having a job is good. When I’m a little older I want to get one at an animal shelter or something. I like playing with dogs.
Kimmy:			I love dogs.
Dana:			We’re looking for people to play games with. Want to play a game with us, Linda?
Linda:			I guess so. I was playing with Donna earlier, but I could play some more.

+ [play with chalk]
{ chalk == true:
	-> Play
	-else: 
	-> No_Games
}

=== Downtown 
-> Done

=== No_Games 
Dana:			Oh no! I’m sorry… I thought I had some stuff to play games with in my bag… but it looks like I ran out.
Kimmy:			Oh no...
Dana:			It’s ok! Kimmy, let’s run to the store and buy some game pieces! We’ll be right back!
-> Playground 

=== Play 
Let's play hopscotch! 
-> Done

=== Done
->DONE