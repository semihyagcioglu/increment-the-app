<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostTask.aspx.cs" Inherits="increment_the_app.PostTask" %>

<asp:Content ID="hc" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="bc" ContentPlaceHolderID="bodyContent" runat="server">

        <h4 class="ch4"><img src="img/find_1.png" alt="Pulpit rock" width="64" height="64">Lütfen Gerekli İş Bilgileri Girin</h4>  
        <hr width=”100%” color=”#0000F8” size=5>
    
      <form role="form">
  <div class="form-group">
    <label class="text-primary">Yapılmak İstenen İş</label>
    <input type="text" class="form-control" id="InputTitle" placeholder="Yapılmak istenen iş...">
  </div>
  <div class="form-group">
    <label class="text-primary">İşin Detayı</label>
    <textarea class="form-control" id="InputTitleDetail" placeholder="Lütfen yapılacak işin detaylarını girin..." rows="3"></textarea>
  </div>
          </form>
    <div class="tarih">
               <div class="tarihlabel"><label class="text-primary">Tarih</label></div>
        <div class="birinci"><select class="form-control" style="width:150px;">
        <option>1</option>
        <option>2</option>
        <option>3</option>
        <option>4</option>
        <option>5</option>
        </select>

        </div>
        <div class="ikinci"><select class="form-control" style="width:150px;">
        <option>Ocak</option>
        <option>Şubat</option>
        <option>Mart</option>
        <option>Nisan</option>
        <option>Mayıs</option>
        </select>

        </div>

        <div class="ucuncu"><select class="form-control" style="width:150px;">
        <option>2014</option>
        <option>2013</option>
        <option>2012</option>
        <option>2011</option>
        <option>2010</option>
        </select>

        </div>

    </div>
             
          <br />

              <div class="btn-group dropup">
  
  <form role="form">
  <div class="form-group">
    <label class="text-primary">Nerede yapılacak ?</label>
    <input type="text" class="form-control" id="Inputlocation" placeholder="Nerede yapılsın...">
  </div>
          </form>
  
                  <br />
                   <form role="form">
  <div class="form-group">
    <label class="text-primary">Ücret ?</label>
     <div class="input-group">
  <input type="text" class="form-control id="InputMoney" placeholder="Ne kadar ödemeyi düşünüyosun..."">
  <span class="input-group-addon">.00 TL</span>
</div>
  </div>
          </form>
                  <br />

                  <div id="btnTaskSave" class="btn btn-lg btn-success btn-block">Kaydet ve Teklif Al</div>
        </div>
</asp:Content>
<asp:Content ID="fc" ContentPlaceHolderID="footerContent" runat="server">
</asp:Content>