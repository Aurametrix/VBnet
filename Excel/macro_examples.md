It is possible to write a macro without writing a single line of code

Macro for a shortcut (e.g. for saving the file)

1. Go to the Developer tab, and select Record Macro (first in the code group to the left)

2. Select Begin recording.

3. Assign the shortcut as follows:
   a. Select Keyboard.
   
   b. Select the macro you are currently recording from the Commands box.
   
   c. Type the sequence you want to use in the Press new shortcut key box.
   
   d. Close, and your macro will begin recording

4. Carry out whichever action you want to automate. 
For example, if you are making a simple macro for saving a file, click File then Save. 
Make it something easy, even if a shortcut already exists.

5. Click Stop recording.

Macro for typing a particular phone number with shortcut key+CTRL+e

1. View

2. Drop down under macros

3. Click record Macro

4. Name Macro "Phone"

5. Assign Shortcut Key;

OK;

6. Type the phone (xxx-xxx-xxxx) in a cell;

7. Drop down under Macros;

8. Click Stop recording

To run this macro:

1. View Tab;

2. Macros Button;

3. Run


To Avoid Receiving one of these messages:
Not Enough Stack Space to Run Macro
-or-
Error 28: Out of Stack Space
-or-
Run-time error '28':
Out of stack space

when you call nested dialog boxes, do not assign a dialog control (such as a button or a check box) to a macro event that calls another dialog box. Instead, assign the control to first dismiss the active dialog box, then call the desired dialog box from the same the macro that called the first dialog box. To dismiss the active dialog box, do any of the following: 

Format the control with the Dismiss property:

Select the control and choose Object from Format menu.
In the Format Object dialog box, select the Dismiss check box on the Control tab.
-or-

Assign the control to a macro that contains the following command:
      ActiveDialog.Hide
						
-or-

Format the control with the Cancel property:

Select the control and choose Object from Format menu.
In the Format Object dialog box, Select the Cancel check box on the Control tab.
For an additional workaround, please see the following article(s) in the Microsoft Knowledge Base:
125805 XL: Displaying Several Dialog Boxes Without Looping
