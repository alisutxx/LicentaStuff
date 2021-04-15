function AddGltfObj(id) {
    var frame = document.getElementById('myFrame');
    var doc = frame.contentDocument || frame.contentWindow.document;
    var sceneEl = doc.querySelector('a-scene');
    var entityEl = doc.createElement('a-entity');
    switch (id) {
        case "1": {
            entityEl.setAttribute('gltf-model', 'url(1.gltf)');
            entityEl.setAttribute('scale', '0.150 0.170 0.120');
            entityEl.setAttribute('dragndrop', '');
            break;
        }
        case "2": {
            entityEl.setAttribute('gltf-model', 'url(2.gltf)');
            entityEl.setAttribute('scale', '0.150 0.150 0.150');
            entityEl.setAttribute('dragndrop', '');
            break;
        }
        case "4": {
            entityEl.setAttribute('gltf-model', 'url(4.gltf)');
            entityEl.setAttribute('scale', '0.1 0.1 0.1');
            entityEl.setAttribute('dragndrop', '');
            break;
        }
        case "5": {
            entityEl.setAttribute('gltf-model', 'url(5.gltf)');
            entityEl.setAttribute('scale', '0.009 0.009 0.009');
            entityEl.setAttribute('dragndrop', '');
            break;
        }
        case "7": {
            entityEl.setAttribute('gltf-model', 'url(7.gltf)');
            entityEl.setAttribute('scale', '0.30 0.30 0.30');
            entityEl.setAttribute('dragndrop', '');
            break;
        }
        case "4": {
            entityEl.setAttribute('gltf-model', 'url(1.gltf)');
            entityEl.setAttribute('scale', '0.150 0.170 0.120');
            entityEl.setAttribute('dragndrop', '');
            break;
        }
    }
    sceneEl.appendChild(entityEl);
    }