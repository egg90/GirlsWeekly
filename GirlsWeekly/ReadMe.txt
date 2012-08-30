Windows Phone 7 Sample Application

This demonstrates how to use the Simple Mvvm Toolkit to create a Windows Phone app.
Windows Phone platform does not at this point have support for MEF, although there are
workarounds: See http://www.damonpayne.com/post/2010/06/25/MEF-For-Windows-Phone-7.aspx.
Also WP7 does not natively support commands or Blend's CallMethodAction, so I borrow 
the EventToCommand behavior from the MVVM Light Toolkit for this purpose.

VERSION 2 UPDATE: There is no longer a separate VS item template for the ViewModelLocator
for WP7. In v2 of the toolkit it's the same for both Silverlight and Windows Phone.

1. Add a reference to SimpleMvvmToolkit-WP7
   - You can browse to the assembly located in the Binaries folder:
     SimpleMvvmToolkit\Toolkit\Helpers\Binaries\Windows Phone 7
     or here:
     C:\Program Files\SimpleMvvmToolkit\Binaries\Windows Phone 7
   - Or you can add the SimpleMvvmToolkit-WP7 project to the solution
     and add a project reference to it.

2. Add a new item to the BeautyWeekly project, selecting
   Silverlight/Mvvm/SimpleMvvmViewModelLocator
   a. Add MainPageViewModel using mvvmlocatornosa code snippet
   b. Add CustomerViewModel using mvvmlocator code snippet

3. Lastly, you need to use the EventToCommand behavior to bind the Click
   event of a button to a Command in the view-model

   xmlns:mvvm="clr-namespace:SimpleMvvmToolkit;assembly=SimpleMvvmToolkit-WP7"

   <i:Interaction.Triggers>
    <i:EventTrigger EventName="Click">
        <mvvm:EventToCommand
            Command="{Binding NewCustomerCommand}"/>
    </i:EventTrigger>
   </i:Interaction.Triggers>


   
