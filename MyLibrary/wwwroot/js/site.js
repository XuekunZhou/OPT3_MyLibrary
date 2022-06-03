// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const uri = 'api/todoitems';
let todos = [];

function addEpisode() {
    const addNameTextbox = document.getElementById('add-name');

    fetch(uri, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify()
    })
      .then(response => response.json())
      .then(() => {
        getItems();
        addNameTextbox.value = '';
      })
      .catch(error => console.error('Unable to add item.', error));
  }