if (window.AFRAME == null) {
  console.error("aframe not found, please import it before this component.")
}

AFRAME.registerSystem("track-cursor", {
  init: function() {
    this.el.setAttribute("cursor", { rayOrigin: "mouse" });
  }
});

AFRAME.registerComponent("track-cursor", {
  init: function() {
    this.el.addEventListener("mousedown", e => {
      if (this.el.is("cursor-hovered")) {
        this.el.sceneEl.camera.el.setAttribute("look-controls", {
          enabled: false
        });
        debugger;
        this.el.addState("dragging");
        
      }
    });
    document.addEventListener("keypress", e => {
      if (e.key == 'm') {
        var objects = document.querySelectorAll("a-entity");
        for (let element of objects) {
          if (element.is("dragging")) {
            debugger;
            element.removeState("dragging");
            element.sceneEl.camera.el.setAttribute("look-controls", {
              enabled: true
            });
          }
        }
        }
    });
    window.addEventListener("keydown", e => {
      if (e.key == 'r') {
        //debugger;
          if (this.el.is("dragging")) {
              this.el.object3D.rotation.y += Math.PI/4;
          }
    }
    });
    window.addEventListener("keydown", e => {
      if (e.key == 'd') {
        //debugger;
          if (this.el.is("dragging")) {
            this.el.sceneEl.camera.el.setAttribute("look-controls", {
              enabled: true
            });
            var sceneEl = document.querySelector('a-scene');
            sceneEl.removeChild(this.el);
            
          }
    }
    });
    this.el.addEventListener("click", e => {
      
      if (this.el.is("dragging")) {
        this.el.sceneEl.camera.el.setAttribute("look-controls", {
          enabled: true
        });
        debugger;
        this.el.removeState("dragging");
     
      }
    });
    
    
  }
});

AFRAME.registerComponent("dragndrop", {
  dependencies: ["track-cursor"],
  init: function() {
    this.range = 0;
    this.dist = 0;
    this.el.addEventListener("stateadded", e => {
      
      if (e.detail == "dragging") {
        //debugger;
        this.range = 0;
        this.dist = this.el.object3D.position
          .clone()
          .sub(this.el.sceneEl.camera.el.object3D.position)
          .length(); 
      }
    })
    this.direction = new AFRAME.THREE.Vector3();
    this.target = new AFRAME.THREE.Vector3();
    document.addEventListener("wheel", e => {
      if (e.deltaY < 0) {
        this.range += 0.1;
      } else {
        this.range -= 0.1;
      }
    });
    
  },
  updateDirection: function() {
    this.direction.copy(this.el.sceneEl.getAttribute("raycaster").direction);
  },
  updateTarget: function() {
    let camera = this.el.sceneEl.camera.el
    this.target.copy(
      camera.object3D.position
        .clone()
        .add(this.direction.clone().multiplyScalar(this.dist + this.range))
    );
  },
  tick: function() {
    if (this.el.is("dragging")) {
      this.updateDirection();
      this.updateTarget();
      this.el.object3D.position.copy(this.target);
    }
  }
});