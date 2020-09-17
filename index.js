var itemArrastrable;

document.addEventListener(
  "dragstart",
  (event) => {
    event.dataTransfer.setData("text/plain", null);
    itemArrastrable = event.target;
    event.target.style.opacity = 0.5;
  },
  false
);

document.addEventListener(
  "dragend",
  (event) => {
    event.target.style.opacity = 1;
  },
  false
);

document.addEventListener(
  "dragover",
  (event) => {
    event.preventDefault();
  },
  false
);

document.addEventListener(
  "dragenter",
  (event) => {
    if (event.target.className == "zona-de-soltar") {
      event.target.style.background = "coral";
    }
  },
  false
);

document.addEventListener(
  "dragleave",
  (event) => {
    if (event.target.className == "zona-de-soltar") {
      event.target.style.background = "";
    }
  },
  false
);

document.addEventListener(
  "drop",
  (event) => {
    event.preventDefault();

    if (event.target.className == "zona-de-soltar") {
      event.target.style.background = "";
      itemArrastrable.parentNode.removeChild(itemArrastrable);
      event.target.appendChild(itemArrastrable);
    }
  },
  false
);
