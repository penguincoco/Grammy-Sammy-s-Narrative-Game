//Note: Game disappears after you play it once
VAR chalk = false
VAR wallet = 25
VAR chalk_cost = 5
VAR choice1 = false
VAR choice2 = false
VAR choice3 = false
VAR choice4 = false
VAR player = "Kimmy"

Late 1960s, Massachusetts.

Your mom is standing on the porch. -> Intro_Part_1

=== Intro_Part_1
+ [Talk to Mom]
-> Mom1

=== Mom1
Dana: Mom! Look! God sent me a baby!
Mom: ...Excuse me?
Dana: Her name is Kimmy! -> Kimmy1

 = Kimmy1
+ [It seems that Kimmy has something to say.]
...
(Kimmy remains silent.)
Kimmy: ...

-> Nope

 = Nope
* {X} [...] -> Y
* {not X} [...] -> X

= X
Mom: That… No, Dana. God did not send you a baby.
Dana: What do you mean…? You said God sends people babies sometimes! You told me that.
Mom: Well… nevermind what I said. It doesn’t apply to you. God isn’t about to send you a baby anytime soon, trust me.
 What! Why? I wished for a baby, and he granted my wish. Isn’t it obvious?
Dana: What! Why? I wished for a baby, and he granted my wish. Isn’t it obvious? 

Mom: Where did you find this little girl? Honey, where’s your house? -> Kimmy1

= Y
Mom: Kimmy, can you tell me where your parents are? 

Kimmy: I can go home later if I want… 

Dana: Well maybe God didn’t send her, but she came out of nowhere! 

Kimmy, you just… appeared, right? Where did you come from? 

Kimmy: Ferry Street... I untied myself from the porch so I could go for a walk… 

+[How strange] -> Odd

= Odd
Mom: It’s ok dear, let’s go to your house Kimmy… you said it’s on Ferry Street? Your parents are probably worried. 

+[Head to Kimmy's house] -> Intro_Part_2

=== Intro_Part_2

Dana: I'm sorry... I thought God sent me a baby and I got so excited...

Kimmy's Mom: Oh, don't worry. Thank you for finding Kimmy and walking her home. What's your name, dear? 

Dana: I'm Dana...

Kimmy's Mom: I don't know many kids as responsible as you, walking Kimmy all the way home. I hope you two can be friends. I know Kimmy could learn a lot from you. 

+ [It seems that Kimmy has something to say.] -> continue1

= continue1
Kimmy: My... friend? 

Dana: Yes! I’d love to be friends, Kimmy. Can I come by and play with you tomorrow?

+ [Kimmy's mom looks rather excited] -> continue2

= continue2
Kimmy's Mom: I've been looking for a babysitter, actually. Her grandma was helping with that before, but she... well, she can't anymore. Kimmy's normally alright in her harness on the porch... 
Kimmy's Mom: but she's getting a little old for that... If you'd like to play with Kimmy tomorrow, I'd be happy to pay you a quarter to keep an eye on her.

+ [ Accept the job!] -> continue3

= continue3
Dana: Wow! Yes, please! I'd love to! 
Kimmy's Mom: My work schedule is a little... hectic. It'd be great to have you by in the morning. 
Dana: I'll be here first thing! Wow, I didn't expect to land a job today. Thanks so much! 
Mom: Well, that all sounds good to me. A summer job will be a nice way to keep busy. Now then, let's leave this nice family to their dinner.

+[Go home] -> continue4

= continue4
Dana: Ok. Bye bye, Kimmy, and Mrs...? 
Kimmy's Mom: Mrs. Munro. Again, thank you for giving Kimmy a hand. It was nice meeting you, Mrs. Navaroo. 
Mom: Likewise. 
Kimmy: Bye bye. 

+ [Day 1] -> Day1_Intro

-> Day1_Intro

=== Day1_Intro 
Dana: Mornin’ Kimmy! I’m here to babysit, like I promised! Is your mom around?
Kimmy: My mommy’s not inside. She left already.
Dana: Oh, ok… Um, well… Is there anything you’d like to do today, Kimmy?
Kimmy: No… I don’t know.

+ [Figure out what to do] -> Day1_continue1

= Day1_continue1
Dana: That’s ok, do you have a friend you’d like to visit?
Kimmy: No...
Dana: Should we watch TV or something in your house?
Kimmy: We don’t have a TV. My dad is in there too, so we should go play somewhere else. He’s busy.

+ [Find somewhere else to play] -> Day1_continue2

= Day1_continue2
Dana: Ok then! Want to walk around and play some games with the other kids?
Kimmy: Other kids…?
Dana: You know, the neighborhood kids. 

+ [Like Donna] -> Day1_continue3

= Day1_continue3
Like Donna. Isn’t she your age? You’re both going to be in Kindergarten, right?
Kimmy: Oh, yeah… I don’t think Donna is my friend though, so she probably wouldn’t want to play...
Dana: Well, let’s go become her friend! There's lots of other kids around, too. Like Anthony. I know him from school.
Dana: Come on, let’s go!
Kimmy: ...!

+ [Open Map] -> Map

=== Map
Where would you like to go? 
+ [Store] -> Store
+ [Playground] -> Playground
+ [Quit] -> Done

=== Kimmy_House
// + [Kimmy's Home] -> Kimmy_Home
+ [Store] -> Store.Talk_to_Dean

=== Store
= Talk_to_Dean
Dean: Hey, Kid.
Dana: Hi, Dean. This is Kimmy. I’m babysitting her now.
Dean: Well lookit that, aren’t you all grown up. You gettin’ paid?
Kimmy: My mom pays Dana a quarter a day.
Dana: That’s right! I’m here to buy some things… I mean, I haven’t gotten paid yet. This is my first day. But I have some money saved up!
Dean: Hah, I wish I had that kinda discipline. I blew my budget on fabric last week.
Dana: I need to save up money. For college, you know! My mom would get so mad if I didn’t plan ahead.
Dean: Hah! Your mom’s got the right idea. I wish I’d saved up for college.
Dana: So what did you spend all your money on? Your sewing classes?
Dean: Nah, that’s over. I’m workin’ on some Halloween costumes for my cousins… and some new pants for myself. You know, gotta apply those skills somehow.
Kimmy: I didn’t know people made clothes!
Dean: They do, Kimmy, they do. I make sweaters, dresses, hats--you name it.
Dana: You should sell your clothes at Jordan Marsh! That’s where I always find the nicest clothes.
Dean: Hah! That’s a long ways off for me. But maybe someday… anyways, what can I get for ya?
-> Purchase 

= Exit_Shop
Dana: Thanks, Dean!
Kimmy: Thank you Mr. Dean!
Dean: Bye bye girls. Have fun.

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

* [Linda] -> Linda 
* [Janey] -> Janey
* [Blythe] -> Blythe
+ [Open Map] -> Map

=== Linda

Kimmy: Hi Linda... I haven’t seen you in a while.
Linda: I went to visit my auntie right when school ended.
Dana: Hi, Linda. Do you know Kimmy?
Linda: We’re neighbors.
Kimmy: Did you go far away?
Linda: Auntie’s in Boston.
Kimmy: That sounds far...
Dana: It’s not so far. You can even ride your bike there. Sometimes my sisters and I go. We like to go explore all the clothes shops. Like Filene's.
Linda: I don’t really go shopping, unless it’s for stuffed animals.
Kimmy: Dana is babysitting me, so she can go shopping with the quarters my mom gives her!
Linda: Oh, having a job is good. When I’m a little older I want to get one at an animal shelter or something. I like playing with dogs.
Kimmy: I love dogs.
Dana: We’re looking for people to play games with. Want to play a game with us, Linda?
Linda: I guess so. I was playing with Donna earlier, but I could play some more.
-> Try_Play

=== Janey

Dana: Hey Janey, how are you?
Janey: You know the Grenada movie theatre? I got a summer job there. I started last week.
Kimmy: Wow… my mom took me there once...
Janey: What did you see? I go to the movies a lot, so I bet I saw it too.
Kimmy: Oh… we saw the movie with the… Uh... the fairy godmother and the shoe…
Janey: Cinderella?
Kimmy: Yeah... and we saw Mary Poppins.
Janey: I saw that at The Grenada too. It was so great.
Dana: If we go see a movie there, where would we find you?
Janey: I’m at the snack counter, but I’m too little to be a cashier. I’m helping make popcorn… just until I’m old enough to do something more serious.
Kimmy: I love popcorn!
Janey: Yeah, it’s pretty awesome to be at the snack counter. I love popcorn. I can have free soda whenever I want, too.
Dana: I also have a summer job! I’m babysitting Kimmy! I wasn’t planning on working, but I think it’s great.
Janey: My mom said a summer job is important. I didn’t want her to think I was lazy, and I love movies so I got my cousin to help me get the job. He sells tickets there.
Dana: I’m glad I won’t be lazy this summer. I think I’m getting too old to be lazy. I mean, I’m going into the 5th grade.
Janey: Yeah, it’s more fun to be out with people who aren’t just teachers and classmates too...
Janey: Anyways, I have work now. Talk to you later! 
-> Playground

=== Blythe

Kimmy: P-please go away...
Dana: Blythe, knock it off! I’m a babysitter so you can’t bug me anymore, got it?
Blythe:	Poor Dana. Poor Kimmy. You can’t get away from me! I’m the bicycle lord.
Blythe:	I’ll only stop following you if you play a game with me.
Dana: No.
Blythe:	Yes.
Dana: No.
Blythe: Oh.

-> Playground

=== Try_Play
+ [play with chalk]
{ chalk == true:
	-> Play
	-else: 
	-> No_Games
}

=== No_Games 
Dana: Oh no! I’m sorry… I thought I had some stuff to play games with in my bag… but it looks like I ran out.
Kimmy: Oh no...
Dana: It’s ok! Kimmy, let’s run to the store and buy some game pieces! We’ll be right back!
-> Map

=== Play 
Linda: Hopscotch sounds pretty easy, but... I guess I'll try it
Dana: Okay, I'll teach you how to play...

-> Choice1

= Choice1
+ You need chalk and a rock 
~ choice1 = true 
-> Choice2
+ You need chalk and eggs 
-> Choice2
+ You need chalk and snacks
-> Choice2

= Choice2
+ Then, put the eggs on the ground and draw small squares on the ground around them 
-> Choice3
+ Then, count how many snacks you have and draw that many squares in a column using your chalk 
-> Choice3
+ Then, use your chalk to draw ten squares in a column with some rows containing two squares 
~ choice2 = true
-> Choice3

= Choice3
+ Now, toss the rock into a square and hop to the other end of the column, picking it up on your way back 
~ choice3 = true
-> Choice4
+ Now, each player turns hopping through the egg squares, trying not to squash them 
-> Choice4
+ Now, everyone hops through the squares all at once, trying to pick up the snacks 
-> Choice4

= Choice4
+ You win if you pick up the most snacks 
-> GameOver.incorrect
+ You win if you pick up your rock without falling or tossing it outside of the column ten times 
~ choice4 = true 
-> GameOver.check
+ You win if you finish ten turns without breaking more than one egg 
-> GameOver.incorrect


=== GameOver

= correct 
Linda: That sounds about right!

* [play Hopscotch]

Dana: We did it!
Lina: I usually only play games with my dad or brothers, but that was fun.
Kimmy: Th--thanks for playing with us, Linda.
Linda: I’m going to visit my auntie again in a few weeks, so I’ll see if maybe she’ll want to learn hopscotch thanks for teaching it to me.
Dana: Oh, thank you Linda. You’re a good student!
Linda: I like to learn stuff. I’m glad it’s summer break though… we never get assigned anything fun in school. But my auntie gave me some biology books to read and it’s really fun.
Kimmy: What’s… biology?
Linda: It’s about studying living stuff like plants and animals, and people sometimes too.
Dana: I hope I get to take biology soon. I like math and science classes a lot.
Kimmy: If I could study dogs, I think I’d be happy...

~ chalk = false 
Dana: Wasn't that fun, Kimmy!
Kimmy: Y-yes…
Dana: I think this deserves a sticker. You did a good job! We're gonna keep making you lots of friends...!
-> Playground

= incorrect 
Linda: That doesn't sound right...

-> Playground

= check
{choice1 and choice2 and choice3 and choice4: 
    -> GameOver.correct
    - else: 
    -> GameOver.incorrect
    } 

=== Done
->DONE