AFRAME.registerComponent('wall-change', {
  init: function () {
    var lastIndex = -1;
    var COLORS = ['#3e2b3b','#A2B261','#B26761','#C49A97','#A3E4D7','#BB8FCE','#85929E'];
    var count = 0;
    this.el.addEventListener('click', function (evt) {
      lastIndex = (lastIndex + 1) % COLORS.length;
      this.setAttribute('material', 'repeat', "1 2");
      this.setAttribute('material', 'color', COLORS[lastIndex]);
      console.log('I was clicked at: ', evt.detail.intersection.point);
    });
  }
});