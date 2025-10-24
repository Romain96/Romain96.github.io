function changeLanguageListener()
{
	var value = this.value;
	if (value == "en")
	{
		changeLanguage('en');
	}
	else if (value == "fr")
	{
		changeLanguage('fr');
	}
	else
	{
		// by default in English
		changeLanguage('en');
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
	const response = await fetch(`languages/${lang}.json`);
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