const calendarEl = document.getElementById('calendar');
const modal = document.getElementById('modal');
const selectedDateEl = document.getElementById('selectedDate');
const feedbackInput = document.getElementById('feedbackInput');
const saveBtn = document.getElementById('saveBtn');
const deleteBtn = document.getElementById('deleteBtn');
const closeModalBtn = document.getElementById('closeModal');

let markedDates = {};  // Pode ser inicializado com dados do backend, se quiser
let selectedDate = null;

const apiBaseUrl = 'https://localhost:7165/api/feedbacks'; // ajuste sua URL

// Inicializa Pikaday calendário inline
const picker = new Pikaday({
  field: calendarEl,
  container: calendarEl,
  bound: false,
  format: 'YYYY-MM-DD',
  onSelect: function(date) {
    selectedDate = this.toString('YYYY-MM-DD');
    selectedDateEl.textContent = selectedDate;

    // Carrega feedback do backend para a data selecionada
    carregarFeedback(selectedDate);

    modal.classList.remove('hidden');
  }
});

// Função para carregar feedback da API para a data selecionada
async function carregarFeedback(date) {
  try {
    const response = await fetch(`${apiBaseUrl}`);
    if (!response.ok) throw new Error('Erro ao buscar feedbacks');

    const feedbacks = await response.json();
    const fb = feedbacks.find(f => f.date === date);
    feedbackInput.value = fb ? fb.comment : '';
  } catch (err) {
    alert('Erro ao carregar feedback: ' + err.message);
    feedbackInput.value = '';
  }
}

// Função para salvar feedback via POST na API
async function salvarFeedback(data) {
  try {
    const response = await fetch(apiBaseUrl, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(data),
    });

    if (!response.ok) throw new Error('Erro ao salvar feedback');

    alert('Feedback salvo com sucesso!');
  } catch (err) {
    alert('Erro ao salvar feedback: ' + err.message);
  }
}

// Função para deletar feedback (pode adaptar para backend DELETE)
async function deletarFeedback(date) {
  try {
    // Aqui você pode implementar o DELETE para a API se existir
    alert('Funcionalidade de excluir ainda não implementada no backend.');
  } catch (err) {
    alert('Erro ao excluir feedback: ' + err.message);
  }
}

// Event listeners

saveBtn.addEventListener('click', async () => {
  const text = feedbackInput.value.trim();
  if (!text) {
    alert('Digite algo antes de salvar.');
    return;
  }
  const feedbackData = {
    date: selectedDate,
    comment: text,
    // Adicione userId ou sport se sua API exigir
  };
  await salvarFeedback(feedbackData);
  modal.classList.add('hidden');
});

deleteBtn.addEventListener('click', async () => {
  if (confirm('Tem certeza que deseja excluir o feedback?')) {
    await deletarFeedback(selectedDate);
    feedbackInput.value = '';
    modal.classList.add('hidden');
  }
});

closeModalBtn.addEventListener('click', () => {
  modal.classList.add('hidden');
});
