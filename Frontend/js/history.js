const loadingEl = document.getElementById('loading');
const feedbackList = document.getElementById('feedbackList');

// Simulação de chamada API (substituir pelo fetch para backend real)
async function getFeedbacks() {
  try {
    const response = await fetch('https://localhost:7165/api/feedbacks');
 
    if (!response.ok) {
      throw new Error('Erro ao buscar feedbacks');
    }
    return await response.json();
  } catch (error) {
    console.error('Erro na API:', error);
    throw error;
  }
}


function renderFeedback(feedback) {
  const li = document.createElement('li');

  const dateEl = document.createElement('div');
  dateEl.className = 'feedback-date';
  dateEl.textContent = feedback.date;

  const sportEl = document.createElement('div');
  sportEl.className = 'feedback-sport';
  sportEl.textContent = feedback.sport;

  const commentEl = document.createElement('div');
  commentEl.className = 'feedback-comment';
  commentEl.textContent = feedback.comment;

  li.appendChild(dateEl);
  li.appendChild(sportEl);
  li.appendChild(commentEl);

  feedbackList.appendChild(li);
}

async function loadData() {
  loadingEl.style.display = 'block';
  feedbackList.innerHTML = '';

  try {
    const feedbacks = await getFeedbacks();
    feedbacks.forEach(renderFeedback);
  } catch (error) {
    loadingEl.textContent = 'Erro ao carregar feedbacks.';
    console.error(error);
  } finally {
    loadingEl.style.display = 'none';
  }
}

loadData();
