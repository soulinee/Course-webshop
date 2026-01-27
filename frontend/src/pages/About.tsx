import React from 'react'

const About = () => {
  return (
    <><h1 className='abouttitle'>
      About
      </h1>
      <p className='aboutparagraph'>
        Deze applicatie is een full-stack course marketplace die werd ontwikkeld om een realistische en professionele webarchitectuur aan te tonen. De frontend is gebouwd met React en focust op een gebruiksvriendelijke interface, state management, routing en formulierafhandeling. De backend is geïmplementeerd in C# en volgt een RESTful API-architectuur. Belangrijke functionaliteiten zijn het zoeken en filteren van cursussen met paginering, veilige authenticatie en een checkout-flow met Stripe voor testbetalingen. Formuliervalidatie wordt consistent afgehandeld met Formik en Yup om correcte gebruikersinput te garanderen vóór data naar de backend wordt verzonden. Het project hanteert een duidelijke scheiding tussen frontend en backend, met aandacht voor schaalbaarheid, onderhoudbaarheid en best practices.
      </p>
      </>
  )
}

export default About