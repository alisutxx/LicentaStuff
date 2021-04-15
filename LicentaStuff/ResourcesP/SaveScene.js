 function SaveScene() {
     var frame = document.getElementById('myFrame');
     var doc = frame.contentDocument || frame.contentWindow.document;
     var sceneEl = doc.querySelector('a-scene'); 
     var html = sceneEl.outerHTML;
     
     //introdu aici instructiune pt trimiterea spre baza de dateee
     console.log(html);
 }