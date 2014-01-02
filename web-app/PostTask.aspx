<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostTask.aspx.cs" Inherits="increment_the_app.PostTask" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

        <h4 class="ch4"><img src="img/find_1.png" alt="Pulpit rock" width="64" height="64">Lütfen Gerekli İş Bilgileri Girin</h4>  
        <hr width=”100%” color=”#0000F8” size=5>
    
      <form role="form">
  <div class="form-group">
    <label class="text-primary">Task Title</label>
    <input type="text" class="form-control" id="exampleInputTitle" placeholder="Task Title">
  </div>
  <div class="form-group">
    <label class="text-primary">Task Description</label>
    <input type="text" class="form-control" id="exampleInputDescription" placeholder="Task Description">
  </div>
          </form>
              <br />

              <label class="text-primary">Where does the Task need to go?</label>
              

    <div class="input-group">
      <span class="input-group-addon">
        <input type="radio">
      </span>
      <input type="text" class="form-control" value="Specific locations">
    </div>

              <div class="input-group">
      <span class="input-group-addon">
        <input type="radio">
      </span>
      <input type="text" class="form-control" value="Nowhere,this Task is virtual">
    </div>

          <br />

              <div class="btn-group dropup">
  <button type="button" class="btn btn-primary">Dropup</button>
  <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
    <span class="caret"></span>
    <span class="sr-only">Toggle Dropdown</span>
  </button>
  <ul class="dropdown-menu">
    <!-- Dropdown menu links -->
  </ul>
                  <br /><br />
                  <br />
        <div class="input-group">
<input type="radio"><span class="yazi">Specific Locations</span> <input type="radio" style="margin-left:15px;" /><span class="yazi">Now Here,this task is Virtual</span>
        </div>

       <div class="form-group">
    
    <input type="text" class="form-control" id="Text1" placeholder="Task Title">
           <label class="text-primary">Add Another Location</label>
  </div>
                  
                  
                  <div class="row">
  <div class="col-lg-6">
    <div class="input-group">
      <div class="input-group-btn">
          <label class="text-primary">I need this Task done by </label>
        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">Date <span class="caret"></span></button>
        <ul class="dropdown-menu">
          <li><a href="#">Date</a></li>
          <li><a href="#">Another action</a></li>
          <li><a href="#">Something else here</a></li>
          <li class="divider"></li>
          <li><a href="#">Separated link</a></li>
        </ul>
      </div><!-- /btn-group -->
        
        
         <input type="text" class="form-control">

    </div><!-- /input-group --></div>
                      <span></span>
                       <div class="row">
  <div class="col-lg-6">
    <div class="input-group">
      <div class="input-group-btn">
        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">At <span class="caret"></span></button>
        <ul class="dropdown-menu">
          <li><a href="#">Date</a></li>
          <li><a href="#">Another action</a></li>
          <li><a href="#">Something else here</a></li>
          <li class="divider"></li>
          <li><a href="#">Separated link</a></li>
        </ul>
      </div><!-- /btn-group -->
         <input type="text" class="form-control">

    </div><!-- /input-group --></div>
                    <br /><br />
            

</div>

        </div>
                  <br />
                  <div class="row">
  <div class="col-lg-6">
    <div class="input-group">
      <div class="input-group-btn">
          <label class="text-primary">I need this Task done by </label>
        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">Lass then <span class="caret"></span></button>
        <ul class="dropdown-menu">
          <li><a href="#">Date</a></li>
          <li><a href="#">Another action</a></li>
          <li><a href="#">Something else here</a></li>
          <li class="divider"></li>
          <li><a href="#">Separated link</a></li>
        </ul>
      </div><!-- /btn-group -->
        
        
         <input type="text" class="form-control">

    </div><!-- /input-group --></div>
                      <span></span>
                       <div class="row">
  <div class="col-lg-6">
   
                    <br /><br />
            

</div>

        </div>
                 
                   
        </div>
<br />
    <label class="text-primary">How much are you willing to pay for this task? </label>
                  <br />
                  <div class="input-group">
  <input type="text" class="form-control">
  <span class="input-group-addon">.00 $ Price Guide</span>
</div>
                  <br />

                 <label class="text-primary">More Details </label>
                  <br />
                  <input type="checkbox" /><span style="color:#808080"> This Task is Private ?</span>
                  <br />
                   <input type="checkbox" /><span style="color:#808080"> This Task repeats regularly ?</span>
        </div>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>