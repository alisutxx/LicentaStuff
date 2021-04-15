AFRAME.registerComponent('floor-change', {
  init: function () {
    var lastIndex = -1;
    var COLORS = ['1.jpg','2.jpg','3.jpg'];
    this.el.addEventListener('click', function (evt) {
      lastIndex = (lastIndex + 1) % COLORS.length;
      this.setAttribute('material', 'repeat', "1 2");
      this.setAttribute('material', 'src', COLORS[lastIndex]);
      console.log('I was clicked at: ', evt.detail.intersection.point);
    });
  }
});