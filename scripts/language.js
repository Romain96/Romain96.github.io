function changeLanguageListener()
{
	var value = this.value;
	alert(value);
	if (value == "en")
	{
		changeLanguage('en');
	}
	else if (value == "fr")
	{
		changeLanguage('fr');
	}
}

function updateContent(langData)
{
	document.querySelectorAll('[data-i18n]').forEach(
		element => 
		{
			const key = element.getAttribute('data-i18n');
			element.innerHTML = langData[key];
		}
	);
}

function setLanguagePreference(lang)
{
	localStorage.setItem('language', lang);
	location.reload();
}

async function fetchLanguageData(lang)
{
	alert(`public/${lang}.json`);
	const response = await fetch(`public/${lang}.json`);
	alert(response);
	return response.json();
}

async function changeLanguage(lang)
{
	await setLanguagePreference(lang);
	const langData = fetchLanguageData(lang);
	updateContent(langData);
}

window.addEventListener('DOMContentLoaded', async () => 
	{
		const userPreferedLanguage = localStorage.getItem('language') || 'en';
		const langData = await fetchLanguageData(userPreferedLanguage);
		updateContent(langData);
	}
);