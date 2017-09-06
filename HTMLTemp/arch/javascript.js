<!DOCTYPE html>
<html>
<body>
<button onclick="myFunction('example')">Try it</button>
<button onclick="myFunction('example2')">Try it</button>
<button onclick="f('exx')">Try it</button>

<div id="1" class="example">11First div element with class="example".</div>
<div id="2" class="exxample2">22Second div element with class="example".</div>
<div id="3" class="example3">33 div element with class="example".</div>

<p>Click the button to change the text of the first div element with class="example" (index 0).</p>



<p><strong>Note:</strong> The getElementsByClassName() method is not supported in Internet Explorer 8 and earlier versions.</p>

<script>
function f(cname){
var x=document.querySelectorAll("[class^="+cname+"]");
alert(x.length);
    for (var i=0;i<x.length;i++){
    	var e=x[i];
    	var d=e.style.display;
	    e.style.display = (e.style.display == 'block') ? 'none' : 'block';
    }
}
function myFunction(cname) {
    var x = document.getElementById("1");
    for (var i=0;i<x.length;i++){
    	var e=x[i];
    	var d=e.style.display;
	    e.style.display = (e.style.display == 'block') ? 'none' : 'block';
    }
}

</script>

</body>
</html>
