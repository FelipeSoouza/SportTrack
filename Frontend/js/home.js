const sports = ['Jiu Jitsu', 'Muay Thai'];
let selectedSport = 'Jiu Jitsu';

const selectedSportSpan = document.getElementById('selectedSport');
const modal = document.getElementById('modal');
const sportsList = document.getElementById('sportsList');
const closeModalBtn = document.getElementById('closeModal');

function renderSports() {
  sportsList.innerHTML = '';
  sports.forEach(sport => {
    const li = document.createElement('li');
    li.textContent = sport;
    li.addEventListener('click', () => {
      selectedSport = sport;
      selectedSportSpan.textContent = selectedSport;
      closeModal();
    });
    sportsList.appendChild(li);
  });
}

function openModal() {
  modal.classList.remove('hidden');
}

function closeModal() {
  modal.classList.add('hidden');
}

document.getElementById('btnChangeSport').addEventListener('click', openModal);
closeModalBtn.addEventListener('click', closeModal);

document.getElementById('btnCalendar').addEventListener('click', () => {
  window.location.href = 'calendar.html';
});

document.getElementById('btnHistory').addEventListener('click', () => {
  window.location.href = 'history.html';
});

document.getElementById('btnStats').addEventListener('click', () => {
  window.location.href = 'stats.html'; // Caso tenha essa página, senão remova ou altere
});

renderSports();
